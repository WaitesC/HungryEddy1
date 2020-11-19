using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialController : MonoBehaviour
{
    GameManager gameManager;

    public List<GameObject> tutorialPages;

    int currentPageNum, totalPageNum;

    bool pressedButtonDown = false;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        totalPageNum = tutorialPages.Count;
        currentPageNum = 0;

        foreach (GameObject tutorialPage in tutorialPages)
            tutorialPage.SetActive(false);

        tutorialPages[currentPageNum].SetActive(true);

    }

    void Update()
    {
        tutorialPages[currentPageNum].SetActive(true);
        if (currentPageNum != 8)
            tutorialPages[currentPageNum + 1].SetActive(false);
        if (currentPageNum != 0)
            tutorialPages[currentPageNum - 1].SetActive(false);

        //if (currentPageNum > 7)
        //    currentPageNum = 7;
        
        //if (currentPageNum < 1)
        //    currentPageNum = 1;

        if (gameManager.tutorialTime)
        {
            if (Input.GetAxisRaw("Horizontal") > 0 && currentPageNum <8)
            {
                if(pressedButtonDown == false)
                {
                    currentPageNum += 1;

                    pressedButtonDown = true;
                }

            }
            
            if (Input.GetAxisRaw("Horizontal") < 0 && currentPageNum > 0)
            {
                if (pressedButtonDown == false)
                {
                    currentPageNum -= 1;

                    pressedButtonDown = true;
                }
            }

            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                pressedButtonDown = false;
            }



            if (currentPageNum == 8 && Input.GetAxisRaw("Horizontal") > 0)
            {

                if (pressedButtonDown == false)
                {
                    gameManager.tutorialTime = false;

                    pressedButtonDown = true;
                }
            }
            
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                gameManager.tutorialTime = false;
            }
        }
        else
        {
            foreach (GameObject tutorialPage in tutorialPages)
                tutorialPage.SetActive(false);
        }

    }
}
