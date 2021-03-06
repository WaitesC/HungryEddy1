﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaterpillarUnit : MonoBehaviour
{
    public int maxHealth = 100;
    public int healthUp = 10;
    public int xP = 100;
    public int speed = 20;

    int currentHealth;
    Animator animator;

    public AudioSource source;
    public AudioClip eatenSound;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //play hurt animation
        //Debug.Log("Enemy died");

        if (currentHealth <= 0)
        {
            //Die();
            StartCoroutine("CaterpillarEaten");
        }
            
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            rb.gravityScale = 0.0f;

            rb.velocity = Vector3.zero;

            rb.constraints = RigidbodyConstraints2D.FreezePosition;

            //play death animation
            animator.SetTrigger("CaterpillarDie");

            StartCoroutine("CaterpillarDie");


            //Debug.Log("Enemy died");

        }
    }
    

    void Die()
    {
        //Debug.Log("Enemy died");

        //die animation

        //diable enemy
        Destroy(gameObject);
    }
    
    IEnumerator CaterpillarDie()
    {
        yield return new WaitForSeconds(1f);

        Destroy(gameObject);

    }
    
    IEnumerator CaterpillarEaten()
    {
        source.PlayOneShot(eatenSound, 1f);

        yield return new WaitForSeconds(0.3f);


        Destroy(gameObject);

    }
}
