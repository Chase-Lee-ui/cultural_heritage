using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneWayPlatform : MonoBehaviour
{
    public bool isUp;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S) && this.Player.GetComponent<Player_Movement>().OnGround)
        {
            this.transform.parent.GetComponent<Collider2D>().enabled = false;
        }
    
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            this.gameObject.transform.parent.GetComponent<Collider2D>().enabled = isUp;
        }
    }
}
