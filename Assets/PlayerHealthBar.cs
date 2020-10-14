using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider slider;

    public GameObject player;

    void Update()
    {
        SetPlayerHealthBar();
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        //slider.value = health;

    }

    public void SetCurrentHealth(float health)
    {
        slider.value = health;
    }

    public float PlayerCurrentHealth()
    {
        float playerCurrentHealth = player.GetComponent<HealthController>().currentHealth;

        return playerCurrentHealth;
    }

    public float PlayerMaxHealth()
    {
        float playerMaxHealth = player.GetComponent<HealthController>().maxHealth;

        return playerMaxHealth;
    }


    void SetPlayerHealthBar()
    {
        SetCurrentHealth(PlayerCurrentHealth());
        SetMaxHealth(PlayerMaxHealth());
    }

}
