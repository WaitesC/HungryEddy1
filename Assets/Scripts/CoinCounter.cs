using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    AudioSource source;
    
    public bool isBigCoin;

    public int smallCoinValue;
    public int bigCoinValue;

    public AudioClip smallCoinSound;
    public AudioClip bigCoinSound;

    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2D;

    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(isBigCoin == false)
        {
            //if player picks up small coin
            if (collider.gameObject.tag == "Player")
            {
                FindObjectOfType<GameManager>().currentCoins += smallCoinValue;

                source.PlayOneShot(smallCoinSound, 0.3f);

                //Destroy(gameObject);
                OnPickup();
            }
        }
        
        if(isBigCoin == true)
        {
            if (collider.gameObject.tag == "Player")
            {
                FindObjectOfType<GameManager>().currentCoins += bigCoinValue;
                source.PlayOneShot(bigCoinSound, 0.3f);

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
