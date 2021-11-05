using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet_Pick_Up : MonoBehaviour
{
    public bool Hovering;
    private BoxCollider2D PetCollider;
    public GameObject Player;
    private Rigidbody2D PetRB;
    public float JumpHeight;
    public Vector2 FollowBoundsX;
    public Vector2 FollowBoundsY;
    public bool OnPress;
    // Start is called before the first frame update
    void Start()
    {
        this.Hovering = false;
        this.PetCollider = this.gameObject.GetComponent<BoxCollider2D>();
        this.PetRB = this.gameObject.GetComponent<Rigidbody2D>();
        this.OnPress = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        if(this.Hovering && this.OnPress)
        {
            //X refers to negative direction
            //Y refers to positive direction
            var boundsXLeft = this.Player.gameObject.transform.position.x - this.FollowBoundsX.x;
            var boundsXRight = this.Player.gameObject.transform.position.x + this.FollowBoundsX.y;
            var boundsYHigh = this.Player.gameObject.transform.position.y + this.FollowBoundsY.x;
            var boundsYLow = this.Player.gameObject.transform.position.y + this.FollowBoundsY.y;

            var absX = Mathf.Abs(this.Player.gameObject.transform.position.x - this.gameObject.transform.position.x);
            var absY = Mathf.Abs(this.Player.gameObject.transform.position.y - this.gameObject.transform.position.y);

            if(this.transform.position.y <= boundsYLow)
            {
                this.PetRB.AddForce(Vector2.up * this.JumpHeight * 9.8f);
            }
            
            if(this.transform.position.y >= boundsYHigh)
            {
                this.PetRB.AddForce(Vector2.down * this.JumpHeight * 9.8f);
            }

            if(this.transform.position.x <= boundsXLeft)
            {
                this.PetRB.AddForce(Vector2.right * this.JumpHeight * absX);
            }
            
            if(this.transform.position.x >= boundsXRight)
            {
                this.PetRB.AddForce(Vector2.left * this.JumpHeight * absX);
            }
        }
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && this.OnPress)
        {
            this.Hovering = true;
            this.PetCollider.enabled = false;
            this.Player = collision.gameObject;
        }
    }
}
