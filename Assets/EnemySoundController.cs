using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundController : MonoBehaviour
{

    public AudioSource source;
    //public AudioClip enemySound;


    //public float distanceToPlayer;

    //bool nearPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //PlayMySound();


        //if (nearPlayer)
        //{
        //    nearPlayer = false;
        //    source.PlayOneShot(enemySound, 1f);
        //}
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        //source.PlayOneShot(enemySound, 0.3f);

        source.Play();


    }
    
    void OnTriggerExit2D(Collider2D other)
    {

        source.Stop();


    }
}
