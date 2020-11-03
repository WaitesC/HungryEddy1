using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LogoFade : MonoBehaviour
{
    public float fadeSpeed;
    public bool studioTransition;
    public string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(nextScene);

        }

        StartCoroutine(FadingStuff());

        

    }

    IEnumerator FadingStuff()
    {
        yield return new WaitForSeconds(2);

        StartCoroutine(FadeTo(0.0f, 1.0f));

        //yield return new WaitForSeconds(5);

        //StartCoroutine(FadeTo(0.0f, 1.0f));
    }

    //IEnumerator FadeInObject()
    //{
    //    while (this.GetComponent<Renderer>().material.color.a < 1)
    //    {
    //        Color objectColor = this.GetComponent<SpriteRenderer>().color;
    //        float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

    //        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
    //        this.GetComponent<SpriteRenderer>().color = objectColor;
    //        yield return null;
    //    }
    //}

    //IEnumerator FadeOutObject()
    //{
    //    while (this.GetComponent<Renderer>().material.color.a > 0)
    //    {
    //        Color objectColor = this.GetComponent<Renderer>().material.color;
    //        float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

    //        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
    //        this.GetComponent<Renderer>().material.color = objectColor;
    //        yield return null;
    //    }
    //}

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = transform.GetComponent<Image>().material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            transform.GetComponent<Image>().material.color = newColor;
            yield return null;
        }
    }
}
