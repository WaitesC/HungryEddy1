using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingController : MonoBehaviour
{
    public Animator animator;

    public Transform player;
    public Transform swingPosition;

    public LayerMask vineLayers;

    public GameObject tailPointObject;

    public Transform tailPoint;
    public float tailRange = 0.5f;

    public Rigidbody2D rb;


    public PlayerMovement playerMovement;

    bool swinging;
    public bool lookingForVine;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tailPointObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        tailPointObject.SetActive(false);

        if (Input.GetButtonDown("Swing"))
        {
            rb.velocity = Vector3.zero;

            playerMovement.canMove = false;


            animator.SetTrigger("SwingAttack");


        }


        CheckForVines();

        Swing();
    }

    void Swing()
    {
        if (swinging)
        {
            if (Input.GetButtonDown("Jump"))
            {
                //sets player position
                player.position = swingPosition.position;
                //sets jump bool to true for duration of jump
                playerMovement.jump = true;
                //set animation jump trigger
                animator.SetTrigger("Jump");
                //perform jump function
                playerMovement.JumpFunction();
                //no longer swining
                swinging = false;
                //player can move again
                playerMovement.canMove = true;
            }
        }

    }

    void OnDrawGizmosSelected()
    {
        if (tailPoint == null)
            return;

        Gizmos.DrawWireSphere(tailPoint.position, tailRange);

    }

    void CheckForVines()
    {
        Collider2D[] hitVines = Physics2D.OverlapCircleAll(tailPoint.position, tailRange, vineLayers);

        foreach (Collider2D vine in hitVines)
        {
            if(lookingForVine)
            {
                Debug.Log("We hit " + vine.name);

                animator.SetTrigger("HitVine");

                playerMovement.canMove = false;

                swinging = true;
            }
            

            //caterpillar.name.SetActive(false);

            //caterpillar.GetComponent<CaterpillarUnit>().TakeDamage(100);

            //healthController.HealthPickup(caterpillarHealthPickup);
        }
    }

    //IEnumerator MovementDelay
}
