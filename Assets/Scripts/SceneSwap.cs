using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwap : MonoBehaviour
{
    public Vector3 TPTo;
    public GameObject Camera;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.transform.position = this.TPTo;
            this.Camera.transform.position = this.TPTo;
        }
    }
}
