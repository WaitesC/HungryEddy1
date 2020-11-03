using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string nextScene;

    public bool studioTransition;

    bool fadeOut, fadeIn;
    public float fadeSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(nextScene);

        }



        if(studioTransition)
        {
            //StartCoroutine(FadeOutObject());
        }
    }

    IEnumerator FadeInObject()
    {
        while (this.GetComponent<Image>().material.color.a < 1)
        {
            Color objectColor = this.GetComponent<Image>().material.color;
            float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Image>().material.color = objectColor;
            //StartCoroutine(FadeOutObject());

            yield return null;
        }
    }
    
    IEnumerator FadeOutObject()
    {
        while (this.GetComponent<Image>().material.color.a > 0)
        {
            Color objectColor = this.GetComponent<Image>().material.color;
            float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Image>().material.color = objectColor;
            yield return null;
        }
    }

}
