using UnityEngine;

public class BatScript : MonoBehaviour
{
    public float swingForce = 0;
    public BoxCollider2D collider;
    public PlayerController player;
    public GameObject playerObject;
    public float swinging;
    public float lastSwingTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.RB.linearVelocity.x > 0) transform.position = new Vector2(playerObject.transform.position.x + 0.5f, transform.position.y);
        if (player.RB.linearVelocity.x < 0) transform.position = new Vector2(playerObject.transform.position.x - 0.5f, transform.position.y);
        if(swinging)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        else gameObject.GetComponent<Renderer>().enabled = false;

        lastSwingTime--;


    }

    void Swing(float force)
    {
       
    }

}
