using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.XR;

public class BulletScript : MonoBehaviour
{
    public float yspeed;
    public float speed=5;
    public float range = 3;
    public Rigidbody2D RB;
    public GameObject player;
    public float bulletDelay = 2;
    public bool hit;

    public float bulletTime;
    // Start is called before the first frame update
    void Start()
    {
        bulletTime = Time.time;
        player = GameObject.Find("Player");
        
        RB.linearVelocity = (player.transform.position - transform.position).normalized * speed;

        Debug.Log(player.transform.position.x);
        hit = false;
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //    transform.position = new Vector3(transform.position.x + xspeed, transform.position.y + yspeed, 0);

        //RB.linearVelocity = new Vector2(xspeed, yspeed);
        

        if (Time.time > bulletTime + bulletDelay)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Bat") && hit == false)
        {
            RB.linearVelocity *= -1;
            transform.gameObject.tag = "Ricochet";
            hit = true;
            SpriteRenderer m_SpriteRenderer = GetComponent<SpriteRenderer>();
            m_SpriteRenderer.color = Color.blue;
        }

    }
}
