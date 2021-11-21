using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding_Player : MonoBehaviour
{
    public bool Hidden;
    public bool Found;

    void Start()
    {
        this.Hidden = false;
        this.Found = false;
    }
    void Update()
    {
        if(this.Found && !this.Hidden)
        {
            this.gameObject.SetActive(false);
        }
    }
}
