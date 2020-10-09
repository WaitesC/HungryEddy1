using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueController : MonoBehaviour
{
    public Animator animator;

    public Transform tonguePoint;
    public float tongueRange = 0.5f;
    public LayerMask caterpillarLayers;
    

    // Update is called once per frame
    void Update()
    {
        //tongue normal
        if (Input.GetButtonDown("Tongue"))
        {
            Tongue();

        }

        //tongue up
        if (Input.GetButtonDown("Tongue") && Input.GetAxisRaw("Vertical") > 0) 
        {
            TongueUp();

        }
        
        //tongue down
        if (Input.GetButtonDown("Tongue") && Input.GetAxisRaw("Vertical") < 0) 
        {
            TongueDown();

        }


    }

    void Tongue()
    {
        animator.SetTrigger("TongueNormal");

        Collider2D[] hitCaterpillars = Physics2D.OverlapCircleAll(tonguePoint.position, tongueRange, caterpillarLayers);

        foreach(Collider2D caterpillar in hitCaterpillars)
        {
            Debug.Log("We hit " + caterpillar.name);
        }
    }
    
    void TongueUp()
    {
        animator.SetTrigger("TongueUp");

        Collider2D[] hitCaterpillars = Physics2D.OverlapCircleAll(tonguePoint.position, tongueRange, caterpillarLayers);

        foreach(Collider2D caterpillar in hitCaterpillars)
        {
            Debug.Log("We hit " + caterpillar.name);
        }
    }
    
    void TongueDown()
    {
        animator.SetTrigger("TongueDown");

        Collider2D[] hitCaterpillars = Physics2D.OverlapCircleAll(tonguePoint.position, tongueRange, caterpillarLayers);

        foreach(Collider2D caterpillar in hitCaterpillars)
        {
            Debug.Log("We hit " + caterpillar.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (tonguePoint == null)
            return;

        Gizmos.DrawWireSphere(tonguePoint.position, tongueRange);

    }


}
