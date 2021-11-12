using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCarry : MonoBehaviour
{
    public int BlockValue;
    private GameObject Player;
    private bool Holding;
    public Collider2D RemoveOnCarry;
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
                    this.Player = null;
                }
                this.RemoveOnCarry.enabled = !this.RemoveOnCarry.enabled;
                this.Holding = !this.Holding;
            }
            if(this.Holding)
            {
                this.gameObject.transform.position = new Vector3(
                    this.Player.gameObject.transform.position.x, 
                    this.Player.gameObject.transform.position.y - 1.5f, 
                    this.Player.gameObject.transform.position.z);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            this.Player = collision.gameObject;
        }
    }
}
