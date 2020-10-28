using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public Transform tonguePosition;

    public Rigidbody2D playerRigidBody;

    public Animator animator;

    public float runSpeed = 40f;
    public float climbSpeed = 40f;

    public float horMove = 0f;
    float verMove = 0f;

    public bool jump = false;

    public bool canMove;

    public bool climbing;

    public AudioSource source;
    //sounds
    public AudioClip jumpSound;
    public AudioClip tongueSound;
    public AudioClip tailSound;
    public ParticleSystem dust;


    void Start()
    {
        canMove = true;

        //source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
            horMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horMove));

        if (Input.GetButtonDown("Jump") && controller.m_Grounded == true)
        {
            jump = true;
            animator.SetTrigger("Jump");
            //sound effect
            source.PlayOneShot(jumpSound, 0.2f);
            // particle jump effect
            CreateDust();

        }

        if (climbing)
        {
            verMove = Input.GetAxisRaw("Vertical") * climbSpeed;
            canMove = false;
            //controller.verticalMove(verMove * Time.fixedDeltaTime);

            animator.SetBool("Grounded", true);


            //Vector2 movement = new Vector2(0, verMove);

            //playerRigidBody.AddForce(movement * 1);


            //Vector2 movement = new Vector2(1, climbSpeed);
            //transform.Translate(movement * Time.deltaTime);

            if (Input.GetButtonDown("Jump"))
            {
                source.PlayOneShot(jumpSound, 0.3f);



                ////jump sound effect


                //transform.position = tonguePosition.position;

                playerRigidBody.gravityScale = 10f;


                jump = true;

                animator.SetTrigger("Jump");

                JumpFunction();


                climbing = false;


                canMove = true;


                animator.SetBool("OnWall", false);



            }
        }

        Audio();

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

    void Audio()
    {

        if (Input.GetButtonDown("Tongue"))
        {
            //jump sound effect
            //source.PlayOneShot(tongueSound, 0.7f);
        }
        
        if (Input.GetButtonDown("Swing"))
        {
            //jump sound effect
            source.PlayOneShot(tailSound, 0.7f);
        }

    }
    void CreateDust()
    {
        dust.Play();
    }
}
