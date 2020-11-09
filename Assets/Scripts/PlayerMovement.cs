using System.Collections;
using System.Collections.Generic;
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

    //check when falling so can use particle effect
    public bool falling;

    public bool canMove;

    bool crouching = false;

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

        verMove = Input.GetAxisRaw("Vertical");

        //Debug.Log(verMove);



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


        if (verMove == -1f)
        {
            crouching = true;
            //canMove = false;
        }

        if (verMove >= 0)
        {
            crouching = false;
            //canMove = true;


        }

        if (crouching == true)
        {
            animator.SetBool("Crouching", true);

        }
        
        if(crouching == false)
        {
            animator.SetBool("Crouching", false);

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
