using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Level_With_Up : MonoBehaviour
{
    public string NextScene;
 //   public string monkey;
 //   public float forwardInput;
    private bool teleport;
    public GameObject monke;
 //   private Vector3 offset = new Vector3(5, 5, 5);
 //   void Start()
 //   {
 //      this.monke = GameObject.FindWithTag("Player");
 //   }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && teleport) {
            SceneManager.LoadScene(this.NextScene, LoadSceneMode.Single);
        //    transform.position = monke.transform.position + offset;
        }
    }
    void OnTriggerEnter2D (Collider2D collision)
    {
 //       Rigidbody rb = monke.GetComponent<Rigidbody>();
 //       Player_Movement recognize = monke.GetComponent<Player_Movement>();
        if (collision.gameObject.CompareTag("Player"))
        {
            teleport = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        //       Rigidbody rb = monke.GetComponent<Rigidbody>();
        //       Player_Movement recognize = monke.GetComponent<Player_Movement>();
        if (collision.gameObject.CompareTag("Player"))
        {
            teleport = false;
        }
    }
}
