using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAround : MonoBehaviour
{
    public Vector2 XBounds;
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
    }
}
