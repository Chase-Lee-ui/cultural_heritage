using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slammer : MonoBehaviour
{
    public float SpeedUp;
    public float SpeedDown;
    public float TopBound;
    public float BottomBound;
    public bool Lift;
    // Update is called once per frame
    void Update()
    {
        if(Lift)
        {
            this.transform.Translate(Vector2.up * this.SpeedUp * Time.deltaTime);
            if(this.transform.position.y >= this.TopBound)
            {
                this.Lift = !Lift;
            }
        }
        else
        {
            this.transform.Translate(Vector2.down * this.SpeedDown * Time.deltaTime);
            if(this.transform.position.y <= this.BottomBound)
            {
                this.Lift = !Lift;
            }
        }
    }
}
