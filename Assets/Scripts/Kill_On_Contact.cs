using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill_On_Contact : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
