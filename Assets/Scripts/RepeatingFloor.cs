using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingFloor : MonoBehaviour
{

    public float speed;

    public float endX;
    public float startX;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= endX){
            Vector3 pos = new Vector3(startX, transform.position.y, transform.position.z);
            transform.position = pos;
        }
    }
}
