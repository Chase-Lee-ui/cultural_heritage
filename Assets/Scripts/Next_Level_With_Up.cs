using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Level_With_Up : MonoBehaviour
{
    public string NextScene;
    private bool teleport;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && teleport) {
            SceneManager.LoadScene(this.NextScene, LoadSceneMode.Single);
        }
    }
    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            teleport = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            teleport = false;
        }
    }
}
