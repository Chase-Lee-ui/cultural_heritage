using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet_Effect : MonoBehaviour
{
    public Pet_Pick_Up Pet_Pick_Up;
    private BoxCollider2D BoxCollider;
    public Vector3 ScaleChange;
    private Rigidbody2D BoxRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        this.Pet_Pick_Up = this.gameObject.GetComponent<Pet_Pick_Up>();
        this.BoxCollider = this.gameObject.GetComponent<BoxCollider2D>();
        this.BoxRigidbody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && this.Pet_Pick_Up.Player)
        {
            this.Pet_Pick_Up.Hovering = !this.Pet_Pick_Up.Hovering;
            this.BoxCollider.enabled = !this.BoxCollider.enabled;
            this.Pet_Pick_Up.OnPress = !this.Pet_Pick_Up.OnPress;
            if(this.Pet_Pick_Up.Hovering)
            {
                this.gameObject.transform.localScale -= this.ScaleChange;
            }
            else
            {
                this.gameObject.transform.localScale += this.ScaleChange;
                this.BoxRigidbody.velocity = Vector3.zero;
            }
        }
    }
}
