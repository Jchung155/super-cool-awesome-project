using UnityEngine;

public class MeterScript : MonoBehaviour
{
    public GameObject player;
    public PlayerController playerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 0.8f);
        gameObject.transform.localScale = new Vector2(playerScript.charge / playerScript.maxCharge, 0.15f);
    }
}
