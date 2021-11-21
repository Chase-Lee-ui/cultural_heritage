using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;

public class Start_Timer : MonoBehaviour
{
    public float timeRemaining;
    public GameObject[] ToSetActive;
    public GameObject[] ToSetInactive;
    public TextMeshProUGUI CountDown;
    // Update is called once per frame
    void Update()
    {
        if(this.timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }

        if(this.timeRemaining < 0)
        {
            for(int i = 0; i < this.ToSetActive.Length; i++)
            {
                this.ToSetActive[i].SetActive(true);
            }

            for(int i = 0; i < this.ToSetInactive.Length; i++)
            {
                this.ToSetInactive[i].SetActive(false);
            }
        }
        this.UpdateTime();
    }

    public void UpdateTime()
    {
        var min = Math.Floor(this.timeRemaining / 60);
        int sec = (int)this.timeRemaining % 60;
        this.CountDown.text = min + ":" + sec;
    }
}
