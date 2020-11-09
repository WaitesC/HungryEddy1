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

    Animator animator;

    Text coinText;
    Text xPText;

    public AudioClip deathSound;
    public AudioClip winSound;
    public AudioSource source;

    GameObject tutorialStuff;

    GameObject gameUIStuff;

    GameObject gameOverStuff;

    GameObject endLevelStuff;

    PlayerMovement playerMovement;

    Rigidbody2D rb;

    public int currentCoins;
    public int maxCoins;

    public int xPPoints;

    public bool falling;

    bool gameStart = true;
    public bool levelOver = false;

    void Start()
    {
        gameStart = true;

        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();

        animator = GameObject.Find("Player").GetComponent<Animator>();

        tutorialStuff = GameObject.Find("Tutorial Stuff");
        gameUIStuff = GameObject.Find("Game UI stuff");
        gameOverStuff = GameObject.Find("Game Over stuff");
        endLevelStuff = GameObject.Find("End Level stuff");

        coinText = GameObject.Find("Coin Counter Text").GetComponent<Text>();
        xPText = GameObject.Find("XP text").GetComponent<Text>();



    }


    public void GameOver()
    {
        if(gameHasEnded == false)
        {
            Debug.Log("gameovber");
            Invoke("GameOverScreen", 2.3f);
            source.PlayOneShot(deathSound, 0.2f);
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
        source.PlayOneShot(winSound, 0.1f);
        //rb.velocity = new Vector2(0, 0);
        //rb.gravityScale = 0.0f;
        rb.inertia = 0.0f;
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        //playerMovement.animator.Play("Eddy_Idle_2");
        //playerMovement.animator.SetTrigger("HitSomething");
        playerMovement.animator.Play("Eddy_Winning");
        playerMovement.canMove = false;
        gameUIStuff.SetActive(false);

        Invoke("EndLevelUI", 3.0f);
    }

    public void EndLevelUI()
    {
        endLevelStuff.SetActive(true);

    }

}
