using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public GameObject player;
    public PlayerController playerScript;
    public float xBounds = 7;
    public float yBounds = 7;

    // Update is called once per frame
    void Update()
    {
        if (!playerScript.dead)
        {
            float xDifference = transform.position.x - player.transform.position.x;
            float yDifference = transform.position.y - player.transform.position.y;
            if (xDifference > xBounds) transform.position = new Vector3(player.transform.position.x + xBounds, transform.position.y, -10);
            if (xDifference < -xBounds) transform.position = new Vector3(player.transform.position.x - xBounds, transform.position.y, -10);
            if (yDifference > yBounds) transform.position = new Vector3(transform.position.x, player.transform.position.y + yBounds, -10);
            if (yDifference < -yBounds) transform.position = new Vector3(transform.position.x, player.transform.position.y - yBounds, -10);
        }
    }
}
