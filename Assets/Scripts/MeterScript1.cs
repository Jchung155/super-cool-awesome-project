using UnityEngine;

public class MeterScript1 : MonoBehaviour
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
        gameObject.transform.position = new Vector2(player.transform.position.x - 0.5f, player.transform.position.y);
        gameObject.transform.localScale = new Vector2(0.15f, playerScript.rage / playerScript.maxRage);
    }
}
