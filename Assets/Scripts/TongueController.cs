using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueController : MonoBehaviour
{
    public Animator animator;

    public CharacterController2D controller;


    public Transform player;
    public Transform wallPosition;

    public Rigidbody2D rb;

    public Transform tonguePoint;
    public float tongueRange = 0.5f;

    public LayerMask caterpillarLayers;
    public LayerMask wallLayers;

    public float zipSpeed;

    public HealthController healthController;

    public int caterpillarHealthPickup;

    public PlayerMovement playerMovement;

    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //tongue normal
        if (Input.GetButtonDown("Tongue"))
        {
            animator.SetTrigger("TongueNormal");


        }

        //tongue up
        if (Input.GetButtonDown("Tongue") && Input.GetAxisRaw("Vertical") > 0) 
        {
            animator.SetTrigger("TongueUp");


        }
        
        //tongue down
        if (Input.GetButtonDown("Tongue") && Input.GetAxisRaw("Vertical") < 0) 
        {
            animator.SetTrigger("TongueDown");


        }


        CheckForCaterpillars();

        CheckForWalls();

    }


    void OnDrawGizmosSelected()
    {
        if (tonguePoint == null)
            return;

        Gizmos.DrawWireSphere(tonguePoint.position, tongueRange);

    }

    void CheckForCaterpillars()
    {
        Collider2D[] hitCaterpillars = Physics2D.OverlapCircleAll(tonguePoint.position, tongueRange, caterpillarLayers);

        foreach (Collider2D caterpillar in hitCaterpillars)
        {

            caterpillar.GetComponent<CaterpillarUnit>().TakeDamage(100);

            healthController.HealthPickup(caterpillarHealthPickup);
        }
    }
    
    void CheckForWalls()
    {
        Collider2D[] hitWalls = Physics2D.OverlapCircleAll(tonguePoint.position, tongueRange, wallLayers);




        foreach (Collider2D wall in hitWalls)
        {
            wallPosition.position = tonguePoint.position;

            animator.SetTrigger("HitSomething");

            //player.transform.position = Vector3.Lerp(player.position, wallPosition.position, zipSpeed);

            rb.MovePosition(wallPosition.position);

            //animator.SetBool("OnWall", true);

            

            //WallMovement();

            //make the zip slower (maybe?)
            //rb.MovePosition(wallPosition.position +transform.position*Time.fixedDeltaTime);

            //Debug.Log("We hit " + wall.name);

        }
    }

    void WallMovement()
    {
        rb.velocity = new Vector2(0, 0);
        rb.gravityScale = 0.0f;

        playerMovement.climbing = true;

        //controller.m_Grounded = true;
        //playerMovement.jump = true;

    }


}
