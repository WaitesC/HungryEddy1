using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public float dot;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth -= dot * Time.deltaTime;

        if(currentHealth<0)
        {
            //die
        }
    }

    public void HealthPickup(int health)
    {
        currentHealth += health;

        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;
    }
}
