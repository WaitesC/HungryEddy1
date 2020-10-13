using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public Animator animator;

    public float runSpeed = 40f;

    float horMove = 0f;

    public bool jump = false;

    public bool canMove;

    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
            horMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetTrigger("Jump");


        }


    }

    void FixedUpdate()
    {
        JumpFunction();
    }

    

    public void JumpFunction()
    {
        controller.Move(horMove * Time.fixedDeltaTime, false, jump);
        jump = false;

    }
}
