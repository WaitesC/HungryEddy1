using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueController : MonoBehaviour
{
    public Animator animator;

    public Transform player;

    public Transform tonguePoint;
    public float tongueRange = 0.5f;
    public LayerMask caterpillarLayers;
    public LayerMask wallLayers;
    

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
            Debug.Log("We hit " + caterpillar.name);
        }
    }
    
    void CheckForWalls()
    {
        Collider2D[] hitWalls = Physics2D.OverlapCircleAll(tonguePoint.position, tongueRange, wallLayers);




        foreach (Collider2D wall in hitWalls)
        {
            
            player.transform.position = Vector3.Lerp(player.position, tonguePoint.position, 0.5f);
            animator.SetTrigger("HitSomething");

            Debug.Log("We hit " + wall.name);

        }
    }


}
