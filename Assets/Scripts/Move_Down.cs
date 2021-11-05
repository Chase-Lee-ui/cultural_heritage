using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Down : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0, this.Speed * inputY, 0);
        transform.Translate(movement * Time.deltaTime);
    }
}
