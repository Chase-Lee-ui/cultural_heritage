using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Vector2 Speed;
    private Rigidbody2D PlayerRB;
    public float JumpHeight;
    public bool OnGround;
    private SpriteRenderer SpriteRenderer;
    private Transform transform;
    private Animator animator;
    public float GravityModifier;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = this.gameObject.GetComponent<Animator>();
        this.transform = this.gameObject.GetComponent<Transform>();
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
            // this.SpriteRenderer.flipX = true;
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(inputX > 0)
        {
            // this.SpriteRenderer.flipX = false;
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        // Vector3 movement = new Vector3(this.Speed.x * Mathf.Abs(inputX), 0, 0);
        Vector2 vel = PlayerRB.velocity;
        vel.x = this.Speed.x * inputX;
        PlayerRB.velocity = vel;
        // transform.Translate(movement * Time.deltaTime);
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
