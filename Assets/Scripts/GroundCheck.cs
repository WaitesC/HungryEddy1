using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    //public bool hitGround;

    public bool falling;
    public bool canPlayLanding;

    //sound stuff
    public AudioSource source;
    public AudioClip landingSound;

    [SerializeField]
    GameObject dustCloud;


    public ParticleSystem landingDust;

    void Start()
    {
        //hitGround = true;
    }

    void Update()
    {
        if (falling)
            canPlayLanding = true;

        
    }

    

    
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Ground") && canPlayLanding)
        {
            //Instantiate(dustCloud, transform.position, dustCloud.transform.rotation);
            landingDust.Play();
            source.PlayOneShot(landingSound, 0.3f);
            canPlayLanding = false;
            falling = false;
            Debug.Log("land");



            //hitGround = true;

            //Debug.Log("land");

            //falling = false;

        }
    }


        //Debug.Log("land");
        //canPlayLanding = false;
    

    //void OnTriggerExit2D(Collider2D col)
    //{
    //    if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
    //        hitGround = false;
    //}

}

