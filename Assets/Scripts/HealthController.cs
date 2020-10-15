using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public float dot;

    public PlayerMovement playerMovement;
    public Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        currentHealth -= dot * Time.deltaTime;

        if(currentHealth<0)
        {
            //die
            playerMovement.canMove = false;
            rb.velocity = new Vector2(0, 0);
            rb.gravityScale = 0.0f;

            FindObjectOfType<GameManager>().GameOver();
        }
    }

    public void HealthPickup(int health)
    {
        currentHealth += health;

        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;
    }
}
