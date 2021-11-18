using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCarry : MonoBehaviour
{
    public int BlockValue;
    public int HoldingBlockValue;
    private GameObject Player;
    private bool Holding;
    // Start is called before the first frame update
    void Start()
    {
        this.Holding = false;
        this.HoldingBlockValue = this.BlockValue;
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
                    this.Player = null;
                }

                this.Holding = !this.Holding;
            }
            if(this.Holding)
            {
                this.gameObject.transform.position = new Vector3(
                    this.Player.gameObject.transform.position.x, 
                    this.Player.gameObject.transform.position.y - 1.5f, 
                    this.Player.gameObject.transform.position.z);
                this.BlockValue = -1;
            }
            else
            {
                this.BlockValue = this.HoldingBlockValue;
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
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
