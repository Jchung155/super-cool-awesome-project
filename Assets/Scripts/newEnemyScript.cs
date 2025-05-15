using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newEnemyScript : MonoBehaviour
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

  
    public GameObject bullet;
    void Start()
    {
        attack = false;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //idle mode
        
        if (attack == false)
        {
            
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
            if (Time.time >= lastShotTime)
            {
                //add the current time to the button delay
                lastShotTime = Time.time + shotDelay;

                //This line of code actually spawns the object. Ignore 'Quaternion.identity' for now
                Instantiate(bullet, transform.position, Quaternion.identity);

            }

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
            other.gameObject.getComponent<
            RB.linearVelocity = new Vector2(Random.Range(1.0f, 3.0f) * sign, Random.Range(3.0f, 5.0f));
        }

        if (other.gameObject.CompareTag("Ball") )
        {
        
          
        }

    }
}


