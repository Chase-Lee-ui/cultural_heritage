using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float attackInterval;

    private float attackTimer;
    private bool attackReady;
    void Start()
    {
        attackTimer = 0;
        attackReady = true;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (attackTimer >= 0)
        {
            attackTimer -= Time.deltaTime;
        } else
        {
            attackReady = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && attackReady)
        {
            anim.SetTrigger("attack");
            attackReady = false;
            attackTimer = attackInterval;
        }
    }
}
