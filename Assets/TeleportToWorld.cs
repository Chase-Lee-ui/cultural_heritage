using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToWorld : MonoBehaviour
{
    [SerializeField] private string NextScene;
    [SerializeField] private float delay;
    [SerializeField] private Animator anim;
    [SerializeField] private Player_Movement playerMovement;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private AnimationController animController;

    private Vector3 currentPos;
    private Vector3 toPos;
    private bool inside;
    private bool isMoving;
    private float startTime;

    private void Start()
    {
        toPos = transform.position;
    }

    void Update()
    {
        if (isMoving)
        {
            float fracComplete = (Time.time - startTime) / delay;
            playerTransform.position = Vector3.Slerp(currentPos, toPos, fracComplete);
        }

        if (Input.GetKeyDown(KeyCode.W) && this.inside)
        {
            StartCoroutine(TeleportPlayer(delay));
        }
    }

    IEnumerator TeleportPlayer(float delay)
    {
        animController.FadeOut();
        isMoving = true;
        startTime = Time.time;
        currentPos = playerTransform.position;
        playerMovement.enabled = false;
        anim.SetTrigger("teleport");
        yield return new WaitForSeconds(delay - 0.1f);
        SceneManager.LoadScene(this.NextScene, LoadSceneMode.Single);
        playerMovement.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.inside = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.inside = false;
        }
    }
}
