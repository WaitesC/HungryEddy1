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
    public Text xPText;

    

    public GameObject tutorialStuff;

    public GameObject gameUIStuff;

    public GameObject gameOverStuff;

    public GameObject endLevelStuff;

    public PlayerMovement playerMovement;

    public Rigidbody2D rb;


    public int currentCoins;
    public int maxCoins;

    public int xPPoints;


    bool gameStart = true;
    public bool levelOver = false;

    void Start()
    {
        gameStart = true;

    }


    public void GameOver()
    {
        if(gameHasEnded == false)
        {
            Debug.Log("gameovber");
            Invoke("GameOverScreen", 5f);

            animator.Play("Eddy_Dead");

        }
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (gameStart)
        {
            StartGameScreen();

        }

        if (gameHasEnded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Restart();
            }
        }

        if(levelOver)
        {
            EndLevel();

            if (Input.GetButtonDown("Jump"))
            {
                Restart();
            }
        }

        coinText.text = currentCoins + " /" + maxCoins;

        xPText.text = " " + xPPoints;
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void GameOverScreen()
    {


        gameHasEnded = true;

        gameOverStuff.SetActive(true);

        gameUIStuff.SetActive(false);



    }

    void StartGameScreen()
    {

        gameUIStuff.SetActive(false);
        gameOverStuff.SetActive(false);
        endLevelStuff.SetActive(false);


        playerMovement.canMove = false;

        if (Input.GetButtonDown("Jump"))
        {
            gameStart = false;
            gameUIStuff.SetActive(true);
            tutorialStuff.SetActive(false);
            playerMovement.canMove = true;

        }

    }

    public void EndLevel()
    {
        //rb.velocity = new Vector2(0, 0);
        //rb.gravityScale = 0.0f;
        rb.inertia = 0.0f;
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        //playerMovement.animator.Play("Eddy_Idle_2");
        playerMovement.animator.SetTrigger("HitSomething");
        playerMovement.canMove = false;
        gameUIStuff.SetActive(false);
        endLevelStuff.SetActive(true);

    }

}
