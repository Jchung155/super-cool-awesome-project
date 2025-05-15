using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newEnemyScript1 : MonoBehaviour
{
    // Start is called before the first frame update

    public bool attack;
    public float speed = 1.5f;
    public Rigidbody2D RB;

    public float lastShotTime;
    public float shotDelay = 0.5f;

    public float turnTime;
    public float turnDelay = 3;

    public GameObject player;
    public PlayerController playerScript;

    public Collider2D Collider;

  
    public GameObject bullet;
    public bool dead;
    void Start()
    {
        attack = false;
        player = GameObject.Find("Player");
        dead = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //idle mode
        
        if (attack == false && !dead)
        {
            speed = 1.5f;
            RB.linearVelocity = new Vector2(speed, RB.linearVelocity.y);

            if (Time.time >= turnTime)
            {
                //add the current time to the button delay
                turnTime = Time.time + turnDelay;

                //This line of code actually spawns the object. Ignore 'Quaternion.identity' for now
                speed *= -1;
                if (speed < 0)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else GetComponent<SpriteRenderer>().flipX = false;

            }


        }
        else
        {
            if (player.transform.position.x < transform.position.x) speed = -4.5f;
            else speed = 4.5f;
            RB.linearVelocity = new Vector2(speed, RB.linearVelocity.y);
        }

        //attack mode

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 5)
        {
            attack = true;
        }
        else if (distance > 10)
        {
            attack = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
 
      
        if (player != null)
        {
            attack = true;
        }
    
    
       if (other.gameObject.CompareTag("Bat"))
         {
            float sign = 1;
            attack = false;
            BatScript batScript = other.gameObject.GetComponent<BatScript>();
            if(batScript.left) sign = -1;
            RB.freezeRotation = false;
            float force = batScript.swingForce;
            Collider.isTrigger = true;
            RB.linearVelocity = new Vector2(0.1f * force * sign, 3.0f);
            Destroy(gameObject, 1.5f);
            gameObject.tag = "Dead";
            dead = true;
            playerScript.rage += force * 0.01f;
        }

        if (other.gameObject.CompareTag("Ball") )
        {
        
          
        }

    }
}


