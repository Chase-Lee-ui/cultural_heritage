using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Hand_Coming : MonoBehaviour
{
    private bool Inside;
    public CinemachineVirtualCamera Camera;
    public GameObject Hand;
    public GameObject LookAtPoint;
    public float Speed;
    public Pig_Button_Mash[] PigsReleased;
    private bool[] Checked = new bool[3];
    private GameObject Player;
    public GameObject SetActive;
    void Update()
    {
        if(this.Inside)
        {
            this.Hand.gameObject.transform.Translate(Vector2.right * this.Speed * Time.deltaTime);
            for(int i = 0; i<this.PigsReleased.Length; i++)
            {
                this.Checked[i] = this.PigsReleased[i].Finished;
            }

            if(this.Checked[0] && this.Checked[1] && this.Checked[2])
            {
                this.Speed = -5;
                this.SetActive.SetActive(true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            this.Player = collision.gameObject;
            this.Camera.m_Lens.FieldOfView = 160f;
            this.Camera.Follow = this.LookAtPoint.gameObject.transform;
            this.Inside = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            this.Player = null;
            this.Camera.m_Lens.FieldOfView = 150f;
            this.Camera.Follow = collision.gameObject.transform;
            this.Inside = false;
        }
    }
}
