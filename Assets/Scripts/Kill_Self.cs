using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill_Self : MonoBehaviour
{
    public float Timer;
    public float TimerEnd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.Timer += Time.deltaTime;
        if(this.Timer >= this.TimerEnd)
        {
            Destroy(this.gameObject);
        }
    }
}
