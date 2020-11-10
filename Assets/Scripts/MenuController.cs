using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    public GameObject StudioPageObj;
    public GameObject SplashLogoObj;
    public GameObject MainMenuObj;
    public GameObject SettingsObj;
    public GameObject ControllerObj;

    public Animator transitionAnimator;

    GameObject transition;

    // Start is called before the first frame update
    void Start()
    {
        transitionAnimator = GameObject.Find("Transition").GetComponent<Animator>();
        transition = GameObject.Find("Transition");

        StudioPage();
        TransitionStart();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TransitionStart()
    {
        //do transition stuff
        transitionAnimator.Play("TransitionAnimationStart");
    }

    void TransitionFull()
    {

    }
    
    void TransitionEnd()
    {
        //do transition stuff
    }

    void TransitionEmpty()
    {

    }

    public void StudioPage()
    {
        StudioPageObj.SetActive(true);
        SplashLogoObj.SetActive(false);
        MainMenuObj.SetActive(false);
        SettingsObj.SetActive(false);
        ControllerObj.SetActive(false);


        Invoke("SplashLogo", 7.0f);
    }

    public void SplashLogo()
    {
        transition.SetActive(false);

        StudioPageObj.SetActive(false);
        SplashLogoObj.SetActive(true);
        MainMenuObj.SetActive(false);
        SettingsObj.SetActive(false);
        ControllerObj.SetActive(false);



    }

    public void MainMenu()
    {
        StudioPageObj.SetActive(false);
        SplashLogoObj.SetActive(false);
        MainMenuObj.SetActive(true);
        SettingsObj.SetActive(false);
        ControllerObj.SetActive(false);


    }

    public void Settings()
    {
        StudioPageObj.SetActive(false);
        SplashLogoObj.SetActive(false);
        MainMenuObj.SetActive(false);
        SettingsObj.SetActive(true);
        ControllerObj.SetActive(false);


    }
    
    public void Controller()
    {
        StudioPageObj.SetActive(false);
        SplashLogoObj.SetActive(false);
        MainMenuObj.SetActive(false);
        SettingsObj.SetActive(false);
        ControllerObj.SetActive(true);


    }

    public void NewGame()
    {
        SceneManager.LoadScene("SampleScene");

    }
}
