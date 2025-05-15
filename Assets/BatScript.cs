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
        transform.position = new Vector2(playerObject.transform.position.x + 1.5f, playerObject.transform.position.y);
        left = false;
        }
        if (player.RB.linearVelocity.x < 0) {
        transform.position = new Vector2(playerObject.transform.position.x - 1.5f, playerObject.transform.position.y);
        left = true;
        }

        if(left){
          transform.position = new Vector2(playerObject.transform.position.x - 1.5f, playerObject.transform.position.y);
        } else transform.position = new Vector2(playerObject.transform.position.x + 1.5f, playerObject.transform.position.y);

        
        if(swinging)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else {
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        lastSwingTime-=Time.deltaTime;
        if (lastSwingTime <= 0 && swinging) {
            swinging = false;
        } 



    }

    public void Swing(float force)
    {
       swinging = true;
       lastSwingTime = 0.15f;
       swingForce = force;

    }

}
