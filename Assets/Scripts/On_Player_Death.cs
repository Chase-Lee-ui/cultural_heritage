using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class On_Player_Death : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] ToSetActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Player.activeSelf)
        {
            for(var i = 0; i < ToSetActive.Length; i++)
            {
                this.ToSetActive[i].SetActive(true);
            }
            
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
    }
}
