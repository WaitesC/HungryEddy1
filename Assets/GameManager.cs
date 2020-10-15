using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public Animator animator;

    public Text coinText;

    public GameObject gameOverText;
    public GameObject gameOverBackground;

    public int currentCoins;
    public int maxCoins;


    public void GameOver()
    {
        if(gameHasEnded == false)
        {
            Debug.Log("gameovber");
            Invoke("GameOverScreen", 1f);

            animator.Play("Eddy_Dead");
        }
    }

    void Update()
    {
        if(gameHasEnded)
        {
            if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space))
            {
                Restart();
            }
        }

        coinText.text = "Coins = " + currentCoins + " /" + maxCoins;
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void GameOverScreen()
    {
        gameHasEnded = true;

        gameOverText.SetActive(true);
        gameOverBackground.SetActive(true);



    }
}
