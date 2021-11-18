using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Level : MonoBehaviour
{
    public string NextScene;
    public bool inside;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && this.inside)
        {
            SceneManager.LoadScene(this.NextScene, LoadSceneMode.Single);
        }
    }
    
    void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            this.inside = true;
        }
    }

    void OnTriggerExit2D (Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            this.inside = false;
        }
    }
}
