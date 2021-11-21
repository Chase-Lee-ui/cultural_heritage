using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCorrect : MonoBehaviour
{
    public int TargetValue;
    public GameObject Pillar;
    public GameObject Prize;
    private bool SetActive;
    void Update()
    {
        if(this.Prize && this.SetActive)
        {
            this.Prize.gameObject.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Puzzle Piece")
        {
            if(collision.gameObject.GetComponent<ItemCarry>().BlockValue == this.TargetValue)
            {
                if(this.Pillar)
                {
                    this.Pillar.GetComponent<LiftUp>().Lift = true;
                }
                if(this.Prize)
                {
                    this.SetActive = true;
                }
            }
        }
    }
}
