using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    //public GameObject StudioPageObj;
    public GameObject SplashLogoObj;
    public GameObject MainMenuObj;
    public GameObject SettingsObj;
    public GameObject ControllerObj;
    public GameObject QuitObj;
    public GameObject CreditsObj;
    public GameObject VolumeObj;

    public GameObject splashConfirmButton, newGameButton, controllerButton, controllerReturnButton, quitYesButton, creditsReturnButton, volumeReturnButton;

    public string firstLevel;


    //GameObject transition;

    void Start()
    {
        
        SplashLogo();

    }

    

    

    public void SplashLogo()
    {
        clearScreen();
        SplashLogoObj.SetActive(true);
        //EventSystem.current.SetSelectedGameObject(splashConfirmButton);

    }

    public void MainMenu()
    {
        clearScreen();
        MainMenuObj.SetActive(true);
        EventSystem.current.SetSelectedGameObject(newGameButton);
    }

    public void Settings()
    {
        clearScreen();
        SettingsObj.SetActive(true);
        EventSystem.current.SetSelectedGameObject(controllerButton);
    }

    public void Controller()
    {
        clearScreen();
        ControllerObj.SetActive(true);
        EventSystem.current.SetSelectedGameObject(controllerReturnButton);
    }

    public void Quit()
    {
        clearScreen();
        QuitObj.SetActive(true);
        EventSystem.current.SetSelectedGameObject(quitYesButton);
    }

    public void Credits()
    {
        clearScreen();
        CreditsObj.SetActive(true);
        EventSystem.current.SetSelectedGameObject(creditsReturnButton);

    }

    public void Volume()
    {
        clearScreen();
        VolumeObj.SetActive(true);
        EventSystem.current.SetSelectedGameObject(volumeReturnButton);

    }

    public void clearScreen()
    {
        //EventSystem.current.SetSelectedGameObject(null);
        SplashLogoObj.SetActive(false);
        MainMenuObj.SetActive(false);
        SettingsObj.SetActive(false);
        ControllerObj.SetActive(false);
        QuitObj.SetActive(false);
        CreditsObj.SetActive(false);
        VolumeObj.SetActive(false);
    }


    public void NewGame()
    {
        SceneManager.LoadScene(firstLevel);

    }
}
