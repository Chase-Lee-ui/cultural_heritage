using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    private GameObject Player;

    // Update is called once per frame
    void Update()
    {
        if(this.Player)
        {
            var playerRB = this.Player.gameObject.GetComponent<Rigidbody2D>();
            if(playerRB.velocity.x == 0 && playerRB.velocity.y == 0)
            {
                this.Player.gameObject.GetComponent<Hiding_Player>().Hidden = true;
            }
            else
            {
                this.Player.gameObject.GetComponent<Hiding_Player>().Hidden = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.Player = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.Player.gameObject.GetComponent<Hiding_Player>().Hidden = false;
            this.Player = null;
        }
    }
}
