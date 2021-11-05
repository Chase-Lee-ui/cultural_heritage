using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float Speed;
    public float TopBound;
    public float BottomBound;
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.up * this.Speed * Time.deltaTime);
        if(this.transform.position.y > this.TopBound)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.BottomBound, this.transform.position.z);
        }
    }
}
