using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    GameManager gameManager;

    public bool canIdle;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (canIdle)
            gameManager.canIdle = true;

        if (!canIdle)
            gameManager.canIdle = false;
    }
    
    public void SetHealth(float health)
    {
        slider.value = health;
    }
    
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
}
