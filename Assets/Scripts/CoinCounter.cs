using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    AudioSource source;

    GameManager gameManager;

    bool pickUp;
    
    public bool isBigCoin;

    public int smallCoinValue;
    public int bigCoinValue;

    public AudioClip smallCoinSound;
    public AudioClip bigCoinSound;

    public ParticleSystem smallCoinParticles;
    public ParticleSystem bigCoinParticles;

    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2D;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        source = gameObject.GetComponent<AudioSource>();

        //particleSystem = gameObject.GetComponent<ParticleSystem>();

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();


    }

    void FixedUpdate()
    {
        if(pickUp)
        {
            gameManager.currentCoins += smallCoinValue;

            source.PlayOneShot(smallCoinSound, 0.3f);

            Instantiate(smallCoinParticles, transform.position, Quaternion.identity);

            //Destroy(gameObject);
            OnPickup();


            pickUp = false;
        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(isBigCoin == false)
        {
            //if player picks up small coin
            if (collider.gameObject.tag == "Player")
            {
                pickUp = true;
            }
        }
        
        if(isBigCoin == true)
        {
            if (collider.gameObject.tag == "Player")
            {
                gameManager.currentCoins += bigCoinValue;
                
                source.PlayOneShot(bigCoinSound, 0.3f);

                Instantiate(bigCoinParticles, transform.position, Quaternion.identity);
                // bigCoinParticles.play();

                //Destroy(gameObject);
                OnPickup();
            }
        }
        
    }

    void OnPickup()
    {
        spriteRenderer.enabled = false;
        boxCollider2D.enabled = false;

    }
}
