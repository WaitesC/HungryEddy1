using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueController : MonoBehaviour
{
    public Animator animator;

    public Transform player;
    public Transform wallPosition;

    public Rigidbody2D rb;

    public Transform tonguePoint;
    public float tongueRange = 0.5f;

    public LayerMask caterpillarLayers;
    public LayerMask wallLayers;

    public float zipSpeed;

    public HealthController healthController;
    
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

            Tongue();

        }

        //tongue up
        if (Input.GetButtonDown("Tongue") && Input.GetAxisRaw("Vertical") > 0) 
        {
            animator.SetTrigger("TongueUp");

            TongueUp();

        }
        
        //tongue down
        if (Input.GetButtonDown("Tongue") && Input.GetAxisRaw("Vertical") < 0) 
        {
            animator.SetTrigger("TongueDown");

            TongueDown();

        }


        CheckForCaterpillars();

        CheckForWalls();

    }

    void Tongue()
    {

        

    }

    void TongueUp()
    {



    }

    void TongueDown()
    {


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
            //Debug.Log("We hit " + caterpillar.name);
            //caterpillar.name.SetActive(false);

            caterpillar.GetComponent<CaterpillarUnit>().TakeDamage(100);

            healthController.HealthPickup(5);
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

            //make the zip slower (maybe?)
            //rb.MovePosition(wallPosition.position +transform.position*Time.fixedDeltaTime);

            Debug.Log("We hit " + wall.name);

        }
    }


}
