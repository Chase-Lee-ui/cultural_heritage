using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carry_Artifact : MonoBehaviour
{
    private GameObject Player;
    private bool Holding;
    // Start is called before the first frame update
    void Start()
    {
        this.Holding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.Player)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                if(this.Holding)
                {
                    this.Player.gameObject.transform.root.GetComponent<Player_Movement>().Speed.x += 10;
                    this.Player.gameObject.transform.root.GetComponent<Player_Movement>().JumpHeight += 70;
                    this.Player = null;
                }
                this.Holding = !this.Holding;
                this.Player.gameObject.transform.root.GetComponent<Player_Movement>().Speed.x -= 10;
                this.Player.gameObject.transform.root.GetComponent<Player_Movement>().JumpHeight -= 70;
            }
            if(this.Holding)
            {
                this.gameObject.transform.position = new Vector3(
                    this.Player.gameObject.transform.root.position.x + 1.5f, 
                    this.Player.gameObject.transform.root.position.y, 
                    this.Player.gameObject.transform.root.position.z);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Hand")
        {
            this.Player = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Hand")
        {
            this.Player = null;
        }
    }
}
