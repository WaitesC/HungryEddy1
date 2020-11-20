using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;

    Animator animator;

    Text coinText;
    Text coinTextEnd;
    Text xPText;

    int coinNum;

    public AudioClip deathSound;
    public AudioClip winSound;
    public AudioSource EndScreenSound;
    public AudioSource dieSound;

    GameObject tutorial1;

    GameObject gameUIStuff;

    GameObject gameOverStuff;

    GameObject endLevelStuff;

    PlayerMovement playerMovement;

    Rigidbody2D rb;

    public int currentCoins;
    public int maxCoins;

    public int xPPoints;

    public bool falling;
    public bool okToFlash;

    bool gameStart = true;
    public bool tutorialTime = false;
    public bool levelOver = false;
    bool hasDied;
    bool finished;

    bool onEndLevelScreen;

    void Start()
    {
        hasDied = false;
        finished = false;
        gameStart = true;
        onEndLevelScreen = false;
        okToFlash = true;

        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();

        animator = GameObject.Find("Player").GetComponent<Animator>();

        //tutorial1 = GameObject.Find("Tutorial 1");
        gameUIStuff = GameObject.Find("Game UI stuff");
        gameOverStuff = GameObject.Find("Game Over stuff");
        endLevelStuff = GameObject.Find("End Level stuff");

        maxCoins = GameObject.FindGameObjectsWithTag("SmallCoin").Length;

        coinText = GameObject.Find("Coin Counter Text").GetComponent<Text>();
        coinTextEnd = GameObject.Find("Coin Counter Text End").GetComponent<Text>();
        xPText = GameObject.Find("XP text").GetComponent<Text>();

        //maxCoins = coinNum;


        CanvasStart();


        if (SceneManager.GetActiveScene().name == "Level 1")
            Level1Tutorial();
    }

    public void Level1Tutorial()
    {
        playerMovement.canMove = false;
        //gameUIStuff.SetActive(false);
        //tutorial1.SetActive(true);
        tutorialTime = true;
    }

    public void EndTutorial()
    {
        CanvasStart();
        playerMovement.canMove = true;
        //gameUIStuff.SetActive(true);
    }


    void CanvasStart()
    {
        gameOverStuff.SetActive(false);
        endLevelStuff.SetActive(false);
        //tutorial1.SetActive(false);
    }


    public void GameOver()
    {
        if(gameHasEnded == false)
        {
            
            animator.Play("Eddy_Dead");

            dieSound.loop = false;
            dieSound.Play(0);


            Invoke("GameOverScreen", 2.3f);

            gameHasEnded = true;
        }
    }

    void Update()
    {
        if(onEndLevelScreen)
        {
            if (Input.GetButtonDown("Pause"))
                SceneManager.LoadScene("Main Menu");

            if (Input.GetButtonDown("Jump"))
                Restart();

        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (tutorialTime)
        {
            playerMovement.canMove = false;


        }
        else
            playerMovement.canMove = true;

        if (gameHasEnded)
        {
            if (Input.GetButtonDown("Jump"))
                Restart();
            

            if (Input.GetButtonDown("Pause"))
                SceneManager.LoadScene("Main Menu");
        }

        if(levelOver)
        {
            EndLevel();

            
        }

        //if (SceneManager.GetActiveScene().name == "Level 1")
        //    maxCoins = 40;

        //coinText.text = currentCoins + " /" + maxCoins;
        coinText.text = currentCoins + " ";
        //coinTextEnd.text = currentCoins + " /" + maxCoins;
        coinTextEnd.text = currentCoins + " ";

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

        EndScreenSound.Play(0);

        animator.Play("Eddy_Dead 0");


    }

    void StartGameScreen()
    {

        //gameUIStuff.SetActive(false);
        //gameOverStuff.SetActive(false);
        //endLevelStuff.SetActive(false);


        //playerMovement.canMove = false;

        //if (Input.GetButtonDown("Jump"))
        //{
            //gameStart = false;
            gameUIStuff.SetActive(true);
            //tutorialStuff.SetActive(false);
            playerMovement.canMove = true;

        //}

    }

    public void EndLevel()
    {
        if(finished == false)
        {
            EndScreenSound.PlayOneShot(winSound, 0.1f);
            finished = true;
        }
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

        onEndLevelScreen = true;

        
    }

}
