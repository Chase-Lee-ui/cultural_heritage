using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAround : MonoBehaviour
{
    public Vector2 XBounds;
    public float PeriodicJumnps;
    private bool GoingRight;
    public float Speed;
    private SpriteRenderer Sprite;
    void Start()
    {
        this.Sprite = this.gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(this.GoingRight)
        {
            this.transform.Translate(Vector2.right * this.Speed * Time.deltaTime);
            if(this.gameObject.transform.position.x >= this.XBounds.y)
            {
                this.Sprite.flipX = !this.Sprite.flipX;
                this.GoingRight = !this.GoingRight;
            }
        }
        else
        {
            this.transform.Translate(Vector2.left * this.Speed * Time.deltaTime);
            if(this.gameObject.transform.position.x <= this.XBounds.x)
            {
                this.Sprite.flipX = !this.Sprite.flipX;
                this.GoingRight = !this.GoingRight;
            }
        }

        this.PeriodicJumnps -= Time.deltaTime;
        if(this.PeriodicJumnps <= 0)
        {
            this.PeriodicJumnps = 5.0f;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100.0f * 9.8f);
        }
    }
}
