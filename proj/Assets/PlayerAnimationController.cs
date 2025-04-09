using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        if (moveX == 0 && moveY == 0)
        {
            animator.SetBool("isWalking", false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Jump");
            }
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Punch");
            }
        }
        else
        {
            animator.SetBool("isWalking", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.W))
        {
            animator.SetTrigger("RJump");
        }
    }
}
