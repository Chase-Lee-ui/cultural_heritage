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
    // public GameObject LookAtObject;

    // Start is called before the first frame update
    void Start()
    {
        this.StartTime = Time.time;
        this.Dialog.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        //slerping camera to look at dialog
        if(EnteredScene)
        {
            if(Camera.Follow.position != this.LookAtTransform.position)
            {
                this.Camera.Follow.position = Vector3.Slerp(this.CurrentPosition.position, this.LookAtTransform.position, Time.deltaTime);
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
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            this.EnteredScene = true;
            this.Player = collision.gameObject;
            //saves monke transform
            this.CurrentPosition = collision.gameObject.transform;
            //saves monke movement
            this.PlayerMovementScript = collision.gameObject.GetComponent<Player_Movement>();
            this.PlayerMovementScript.enabled = false;
            // var NewTransform = new GameObject();
            // NewTransform.position = this.CurrentPosition.position;
            // this.Camera.Follow = NewTransform;
        }
    }
}
