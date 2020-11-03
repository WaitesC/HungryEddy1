using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    bool hitGround;


    [SerializeField]
    GameObject dustCloud;

    public ParticleSystem landingDust;

    void Start()
    {
        hitGround = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //if (col.gameObject.tag.Equals("Ground") && hitGround == false)
        if(col.gameObject.layer == LayerMask.NameToLayer("Ground") && hitGround == false)
        {
            //Instantiate(dustCloud, transform.position, dustCloud.transform.rotation);

            landingDust.Play();

            hitGround = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
            hitGround = false;
    }

}

