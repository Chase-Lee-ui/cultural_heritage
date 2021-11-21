using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig_Button_Mash : MonoBehaviour
{
    private int ButtonMash;
    private bool Inside;
    public int TotalToPress;
    public GameObject ReleasePig;
    public GameObject SetInactive;
    public bool Finished;
    // Start is called before the first frame update
    void Start()
    {
        this.ButtonMash = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && this.Inside)
        {
            this.ButtonMash += 1;
            if(this.ButtonMash >= this.TotalToPress)
            {
                this.SetInactive.SetActive(false);
                this.ReleasePig.SetActive(true);
                this.Finished = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            this.Inside = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            this.Inside = false;
        }
    }
}
