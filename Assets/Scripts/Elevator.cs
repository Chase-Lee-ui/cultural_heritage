using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float Speed;
    public float TopBound;
    public float BottomBound;
    public bool GoingUp;
    // Update is called once per frame
    void Update()
    {
        if(this.GoingUp)
        {
            this.transform.Translate(Vector2.up * this.Speed * Time.deltaTime);
            if(this.gameObject.transform.position.y >= this.TopBound)
            {
                this.GoingUp = !this.GoingUp;
            }
        }
        else
        {
            this.transform.Translate(Vector2.down * this.Speed * Time.deltaTime);
            if(this.gameObject.transform.position.y <= this.BottomBound)
            {
                this.GoingUp = !this.GoingUp;
            }
        }
    }
}
