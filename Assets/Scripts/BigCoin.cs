using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCoin : MonoBehaviour

    
{
    public ParticleSystem bigCoinParticles;

    //private void OnCollisionEnter(Collision collision)
    //private void OnCollisionEnter2D(Collision2D collision2D)
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //if (collision2D.collider.CompareTag("Player"))
        if (collider.gameObject.tag == "Player")
        {
            //destroy();
            particleEffect();
        }
    }

    // public void destroy()
    public void particleEffect()
    {
        Instantiate(bigCoinParticles, transform.position, Quaternion.identity);
        //Destroy(gameObject);
    }

}
