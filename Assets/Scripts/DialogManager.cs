using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class DialogManager : MonoBehaviour
{
    public TextMeshPro Dialog;
    public string[] DialogMessages;
    public float TextSpeed;
    private Player_Movement PlayerMovementScript;
    private GameObject Player;
    public CinemachineVirtualCamera Camera;
    public Transform LookAtTransform;
    private Transform CurrentPosition;
    private int Index;
    private bool EnteredScene;
    private float JourneyTime = 1.0f;
    private float StartTime;
    public GameObject LookAtObject;
    private bool Panning;
    public SpriteRenderer TextBubble;

    // Start is called before the first frame update
    void Start()
    {
        this.Dialog.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        //slerping camera to look at dialog
        if(EnteredScene)
        {
            if(this.Camera.Follow.position != this.LookAtTransform.position && !this.Panning)
            {
                float fracComplete = (Time.time - this.StartTime) / JourneyTime;
                this.LookAtObject.transform.position = Vector3.Slerp(this.CurrentPosition.position, this.LookAtTransform.position, fracComplete);
            }

            if(this.Camera.Follow.position != this.CurrentPosition.position && this.Panning)
            {
                float fracComplete = (Time.time - this.StartTime) / JourneyTime;
                this.LookAtObject.transform.position = Vector3.Slerp(this.LookAtTransform.position, this.CurrentPosition.position, fracComplete);
                var Alpha = Mathf.Abs(this.Camera.Follow.position.x - this.CurrentPosition.position.x);
                if((Alpha <= 0.01) && this.Panning)
                {
                    this.Camera.Follow = this.Player.gameObject.transform;
                    this.PlayerMovementScript.enabled = true;
                    this.gameObject.transform.parent.gameObject.SetActive(false);
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(this.Dialog.text == this.DialogMessages[this.Index])
            {
                this.NextLine();
            }
            else
            {
                StopAllCoroutines();
                this.Dialog.text = this.DialogMessages[this.Index];
            }
        }
    }

    void StartDialogue()
    {
        this.Index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in this.DialogMessages[Index].ToCharArray())
        {
            this.Dialog.text += c;
            yield return new WaitForSeconds(this.TextSpeed);
        }
    }

    void NextLine()
    {
        if(this.Index < this.DialogMessages.Length - 1)
        {
            this.Index++;
            this.Dialog.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            this.StartTime = Time.time;
            this.Panning = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            this.TextBubble.enabled = true;
            this.EnteredScene = true;
            this.Player = collision.gameObject;
            //saves monke transform
            this.CurrentPosition = collision.gameObject.transform;
            //saves monke movement
            this.PlayerMovementScript = collision.gameObject.GetComponent<Player_Movement>();
            this.PlayerMovementScript.enabled = false;
            this.LookAtObject.transform.position = collision.gameObject.transform.position;
            this.Camera.Follow = this.LookAtObject.transform;
            this.StartTime = Time.time;
        }
    }
}
