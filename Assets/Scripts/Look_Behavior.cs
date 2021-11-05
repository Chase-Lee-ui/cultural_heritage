using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look_Behavior : MonoBehaviour
{
    public Transform Player;
    private SpriteRenderer SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        this.SpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.Player.transform.position.x < this.transform.position.x)
        {
            this.SpriteRenderer.flipX = true;
        }
        else
        {
            this.SpriteRenderer.flipX = false;
        }
    }
}
