using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnlyPickUp : MonoBehaviour
{
    private GameObject Player;
    [SerializeField] private string artifactName;
    public UnityEvent onPickup;
    public bool Holding;
    void Update()
    {
        if(this.Player)
        {
            if(Input.GetKeyDown(KeyCode.Q) && !Holding)
            {
                this.Holding = true;
                if (artifactName != null)
                {
                    PlayerPrefs.SetInt(artifactName, 1);
                    onPickup.Invoke();
                }
            }
            if(this.Holding)
            {
                this.gameObject.transform.position = new Vector3(
                    this.Player.gameObject.transform.position.x, 
                    this.Player.gameObject.transform.position.y - 1.5f, 
                    this.Player.gameObject.transform.position.z);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Hand")
        {
            this.Player = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Hand")
        {
            this.Player = null;
        }
    }
}
