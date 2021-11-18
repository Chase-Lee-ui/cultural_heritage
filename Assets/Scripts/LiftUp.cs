using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftUp : MonoBehaviour
{
    public float SpeedUp;
    public float TopBound;
    public bool Lift = false;
    void Update()
    {
        if(this.Lift)
        {
            this.transform.Translate(Vector2.up * this.SpeedUp * Time.deltaTime);
            if(this.transform.position.y >= this.TopBound)
            {
                this.Lift = !Lift;
            }
        }
    }
}
