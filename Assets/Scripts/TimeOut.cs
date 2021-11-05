using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOut : MonoBehaviour
{
    public float Timer;
    public float TimeEnd;
    // Update is called once per frame
    void Update()
    {
        this.Timer += Time.deltaTime;
        if(this.Timer >= this.TimeEnd)
        {
            Destroy(this.gameObject);
        }
    }
}
