using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D RB;
    public Collider2D Collider;
    public float speed;
    public float jumpSpeed;
    public bool dead = false;
    public Vector2 vel;
    public float torque = 20;
    public float drag = 1;
    public float charge;
    public float maxCharge;
    public float rage;
    public float maxRage;
    public int health;
    public BatScript bat;
    public bool rageMode;
    public SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!dead) {
            vel = new Vector2(RB.linearVelocity.x, RB.linearVelocity.y);

            if (Input.GetKey(KeyCode.RightArrow))
            {
                vel.x = speed;
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (vel.x > 0)
            {
                if (vel.x > drag) vel.x -= drag; else vel.x = 0;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                vel.x = -speed;
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (vel.x < 0)
            {
                if (vel.x < -drag) vel.x += drag; else vel.x = 0;
            }

            if (Input.GetKey(KeyCode.Space) && RB.linearVelocity.y == 0)
            {
                vel.y = jumpSpeed;
            }

            if (Input.GetKey(KeyCode.A) && bat.lastSwingTime <= 0)
            {
                if (charge <= maxCharge)
                {
                    charge++;
                    if (rageMode) charge += 3;
                }
            }

            else if (charge > 30)
            {
                bat.Swing(charge);
                charge = 0;
            }
            else charge = 0;

            if (Input.GetKey(KeyCode.S) && rage >= 0.5f)
            {
                rageMode = true;
            }


            RB.linearVelocity = vel;

            if (rage <= 0)
            {
                rageMode = false;
                spriteRenderer.color = Color.white;
                speed = 6;
            }

            if (rageMode) {
                spriteRenderer.color = Color.red;
                rage -= Time.deltaTime;
                speed = 9;
            }

        
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Hazard") && !dead && !rageMode) Die();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
     
        if (other.gameObject.CompareTag("Hazard") && !dead && !rageMode)
        {
            Die();
        }


    }

    public void Die(){
    dead = true;
    //transform.position = new Vector3(transform.position.x, transform.position.y, 20);

    Debug.Log("Dead");
    Collider.isTrigger = true;
    RB.freezeRotation = false;
        RB.AddTorque(torque);
        int sign = Random.Range(1, 2);
        if (sign == 2) sign = -1;         
        RB.linearVelocity = new Vector2(Random.Range(1.0f, 3.0f)*sign, Random.Range(3.0f,5.0f));

    }
 
}
