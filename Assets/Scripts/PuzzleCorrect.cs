using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCorrect : MonoBehaviour
{
    public int TargetValue;
    public GameObject Pillar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Puzzle Piece")
        {
            if(collision.gameObject.GetComponent<ItemCarry>().BlockValue == this.TargetValue)
            {
                this.Pillar.GetComponent<LiftUp>().Lift = true;
            }
        }
    }
}
