using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Vector2 Speed;
    public float inputY;
    public Rigidbody2D PlayerRB;
    public float JumpHeight;
    public bool OnGround;
    private SpriteRenderer SpriteRenderer;
    public Animator animator;
    public float GravityModifier;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = this.gameObject.GetComponent<Animator>();
        this.PlayerRB = this.gameObject.GetComponent<Rigidbody2D>();
        this.SpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // if(!moveInput)rigidbody.contraints=RigidbodyConstraints.FreezePosition; stop sliding down stairs
    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

        if(this.OnGround && Input.GetKeyDown(KeyCode.Space))
        {
            this.animator.SetBool("isJumping", true);
            this.animator.SetTrigger("takeOff");
            
            PlayerRB.AddForce(Vector2.up * this.JumpHeight * this.GravityModifier);
            this.OnGround = false;
        }

        this.animator.SetBool("isWalking", inputX != 0);

        if(inputX < 0)
        {
            Debug.Log("flip");
            // this.SpriteRenderer.flipX = true;
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(inputX > 0)
        {
            // this.SpriteRenderer.flipX = false;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        // Vector3 movement = new Vector3(this.Speed.x * Mathf.Abs(inputX), 0, 0);
        Vector2 vel = PlayerRB.velocity;
        vel.x = this.Speed.x * inputX;
        PlayerRB.velocity = vel;
        // transform.Translate(movement * Time.deltaTime);
    }

    public void MoveTo(Vector3 position, float t)
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            this.animator.SetBool("takeOff", false);
            this.animator.SetBool("isJumping", false);
            this.OnGround = true;
        }
    }
}
