using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    GameManager gameManager;

    GameObject pauseMenu;

    bool pressedButtonDown = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        pauseMenu = GameObject.Find("Pause Menu");

        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //open pause menu
        if(gameManager.inGame && !gameManager.paused && !gameManager.gameHasEnded && !gameManager.onEndLevelScreen)
        {
            if (Input.GetButtonDown("Pause") &&  pressedButtonDown == false)
            {
                pressedButtonDown = true;
                Debug.Log('p');
                gameManager.paused = true;
                pauseMenu.SetActive(true);
            }

        }


        //close pause menu
        if (gameManager.inGame && gameManager.paused)
        {
            if (Input.GetButtonDown("Pause") && pressedButtonDown == false)
            {
                pressedButtonDown = true;
                gameManager.paused = false;
                pauseMenu.SetActive(false);
            }
            
            if (Input.GetButtonDown("Swing") && pressedButtonDown == false)
            {
                SceneManager.LoadScene("Main Menu");
            }
        }

        if (!Input.GetButtonDown("Pause"))
            pressedButtonDown = false;
    }
}
