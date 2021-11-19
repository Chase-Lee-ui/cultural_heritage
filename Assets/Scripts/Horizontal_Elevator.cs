using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horizontal_Elevator : MonoBehaviour
{
    public float Speed;
    public float RightBound;
    public float LeftBound;
    public bool GoingRight;
    public GameObject Player;
    // Update is called once per frame
    void Update()
    {
        if(this.GoingRight)
        {
            if(Player)
            {
                this.Player.gameObject.transform.Translate(Vector2.right * this.Speed * Time.deltaTime, Space.World);
            }
            this.transform.Translate(Vector2.right * this.Speed * Time.deltaTime);
            if(this.gameObject.transform.position.x >= this.RightBound)
            {
                this.GoingRight = !this.GoingRight;
            }
        }
        else
        {
            if(Player)
            {
                this.Player.gameObject.transform.Translate(Vector2.left * this.Speed * Time.deltaTime, Space.World);
            }
            this.transform.Translate(Vector2.left * this.Speed * Time.deltaTime);
            if(this.gameObject.transform.position.x <= this.LeftBound)
            {
                this.GoingRight = !this.GoingRight;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            this.Player = collision.gameObject;
            this.Player.gameObject.GetComponent<Player_Movement>().Speed.x += this.Speed;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            this.Player.gameObject.GetComponent<Player_Movement>().Speed.x -= this.Speed;
            this.Player = null;
        }
    }
}
