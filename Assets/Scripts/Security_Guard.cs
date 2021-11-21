using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Security_Guard : MonoBehaviour
{
    public Vector2 XBounds;
    public float Speed;
    private bool GoingRight;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(this.GoingRight)
        {
            this.transform.Translate(Vector2.right * this.Speed * Time.deltaTime, Space.World);
            if(this.gameObject.transform.position.x >= this.XBounds.y)
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                this.GoingRight = !this.GoingRight;
            }
        }
        else
        {
            this.transform.Translate(Vector2.left * this.Speed * Time.deltaTime, Space.World);
            if(this.gameObject.transform.position.x <= this.XBounds.x)
            {
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
                this.GoingRight = !this.GoingRight;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Hiding_Player>().Found = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Hiding_Player>().Found = false;
        }
    }
}
