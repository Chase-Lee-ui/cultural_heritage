using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public Pet_Pick_Up Pet_Pick_Up;
    private BoxCollider2D BoxCollider;
    public Vector3 ScaleChange;
    private Rigidbody2D BoxRigidbody;
    private bool Thrown;
    public float Timer;
    public float TimeOut;
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
        this.Timer += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Q) && this.Pet_Pick_Up.Player && !this.Thrown)
        {
            this.Pet_Pick_Up.Hovering = !this.Pet_Pick_Up.Hovering;
            this.BoxCollider.enabled = !this.BoxCollider.enabled;
            this.Pet_Pick_Up.OnPress = !this.Pet_Pick_Up.OnPress;
            this.Thrown = true;
        }

        if(this.Thrown)
        {
            this.BoxRigidbody.AddForce(Vector2.up * 30);
        }

        if(this.Timer >= this.TimeOut && !this.Pet_Pick_Up.Player)
        {
            Destroy(this.gameObject);
        }

        if(this.Timer >= (this.TimeOut + this.TimeOut) && this.Pet_Pick_Up.Player)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
