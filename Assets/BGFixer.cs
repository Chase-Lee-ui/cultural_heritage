using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGFixer : MonoBehaviour
{
    private bool touchingBG;
    public float changeX;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BG")
        {
            touchingBG = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        touchingBG = false;
    }

    private void Update()
    {
        if (touchingBG) {
            Vector2 pos = new Vector2(changeX, transform.position.y);
            this.transform.position = pos;
        }
    }

}
