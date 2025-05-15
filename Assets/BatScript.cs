using UnityEngine;

public class BatScript : MonoBehaviour
{
    public float swingForce = 0;
    public BoxCollider2D collider;
    public PlayerController player;
    public GameObject playerObject;
    public bool swinging;
    public float lastSwingTime;
    public bool left;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        left = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.RB.linearVelocity.x > 0) {
        transform.position = new Vector2(playerObject.transform.position.x + 0.5f, transform.position.y);
        left = false;
        }
        if (player.RB.linearVelocity.x < 0) {
        transform.position = new Vector2(playerObject.transform.position.x - 0.5f, transform.position.y);
        left = true;
        }
        if(swinging)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        else gameObject.GetComponent<Renderer>().enabled = false;

        lastSwingTime-=Time.deltaTime;
        if (lastSwingTime <= 0 && swinging) {
            swinging = false;
        } 



    }

    public void Swing(float force)
    {
       swinging = true;
       lastSwingTime = 1;
       swingForce = force;

    }

}
