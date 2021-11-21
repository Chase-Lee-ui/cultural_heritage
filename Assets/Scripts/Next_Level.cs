using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Level : MonoBehaviour
{
    public string NextScene;
    private bool inside;
    void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(this.NextScene, LoadSceneMode.Single);
        }
    }
}
