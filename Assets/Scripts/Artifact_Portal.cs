using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact_Portal : MonoBehaviour
{
    public int GoalValue;
    private int Counter;
    private TeleportToWorld ActivateScript;
    // Start is called before the first frame update
    void Start()
    {
        this.Counter = 0;
        this.ActivateScript = this.gameObject.GetComponent<TeleportToWorld>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.Counter == this.GoalValue)
        {
            this.ActivateScript.enabled = true;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Puzzle Piece"))
        {
            collision.gameObject.SetActive(false);
            this.Counter += 1;
        }
    }
}
