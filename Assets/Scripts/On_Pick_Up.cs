using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_Pick_Up : MonoBehaviour
{
    private OnlyPickUp ItemCarryScript;
    public GameObject[] SetInActive;
    // Start is called before the first frame update
    void Start()
    {
        this.ItemCarryScript = this.gameObject.GetComponent<OnlyPickUp>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.ItemCarryScript.Holding)
        {
            for(int i = 0; i<SetInActive.Length; i++)
            {
                this.SetInActive[i].gameObject.SetActive(false);
            }
        }
    }
}
