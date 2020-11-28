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

    CharacterController2D characterController2D;

    public PlayerMovement playerMovement;

    bool swinging;

    public bool lookingForVine;

    public float vineOffset;
    public float vineOffsetY;
    public float vineOffsetX;

    public ParticleSystem vineParticles;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tailPointObject.SetActive(false);

        characterController2D = GameObject.Find("Player").GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {

        tailPointObject.SetActive(false);

        if (Input.GetButtonDown("Swing"))
        {
            //rb.velocity = Vector3.zero;

            //playerMovement.canMove = false;

            if(!swinging)
                animator.SetTrigger("SwingAttack");


        }


        CheckForVines();

        Swing();
    }

    void Swing()
    {
        if (swinging)
        {
            characterController2D.m_Grounded = true;

            rb.velocity = Vector3.zero;

            rb.constraints = RigidbodyConstraints2D.FreezePosition;

            playerMovement.canMove = false;

            if (Input.GetButtonDown("Jump"))
            {
                //playerMovement.jump = true;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;

                //sets player position
                player.position = swingPosition.position;
                //no longer swining
                swinging = false;
                //player can move again
                playerMovement.canMove = true;
                //sets jump bool to true for duration of jump
                playerMovement.jump = true;
                //perform jump function
                playerMovement.JumpFunction();
                //set animation jump trigger
                animator.SetTrigger("Jump");
            }
            
            if (Input.GetButtonDown("Swing"))
            {
                animator.Play("Eddy_Idle");
                //playerMovement.jump = true;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;

                //no longer swining
                swinging = false;
                //player can move again
                playerMovement.canMove = true;
            }
            
            if (Input.GetButtonDown("Tongue"))
            {
                animator.Play("Eddy_Idle");
                //playerMovement.jump = true;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;

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
                //Instantiate(vineParticles, swingPosition.position, Quaternion.identity);
                Instantiate(vineParticles, new Vector3(transform.position.x + vineOffsetX, vine.gameObject.transform.position.y, 0), Quaternion.identity);

                Debug.Log("We hit " + vine.name);

                animator.SetTrigger("HitVine");

                playerMovement.canMove = false;

                characterController2D.m_Grounded = true;

                swinging = true;

                gameObject.transform.position = new Vector3 ( transform.position.x, vine.gameObject.transform.position.y + vineOffsetY, 0);
            }
            

            //caterpillar.name.SetActive(false);

            //caterpillar.GetComponent<CaterpillarUnit>().TakeDamage(100);

            //healthController.HealthPickup(caterpillarHealthPickup);
        }
    }

    //IEnumerator MovementDelay
}
