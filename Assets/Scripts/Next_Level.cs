using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Level : MonoBehaviour
{
    public string NextScene;
    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(this.NextScene, LoadSceneMode.Single);
        }
    }
}
