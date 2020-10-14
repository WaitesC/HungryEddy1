using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public Rigidbody2D playerRigidBody;

    public Animator animator;

    public float runSpeed = 40f;
    public float climbSpeed = 40f;

    float horMove = 0f;
    float verMove = 0f;

    public bool jump = false;

    public bool canMove;

    public bool climbing;

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

        if(climbing)
        {
            verMove = Input.GetAxisRaw("Vertical") * climbSpeed;
            canMove = false;

            //Vector2 movement = new Vector2(0, verMove);

            //playerRigidBody.AddForce(movement * 1);

            controller.verticalMove(verMove * Time.fixedDeltaTime);

            //Vector2 movement = new Vector2(1, climbSpeed);
            //transform.Translate(movement * Time.deltaTime);

            if (Input.GetButtonDown("Jump"))
            {
                climbing = false;
                canMove = true;
                playerRigidBody.gravityScale = 10f;

            }
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
