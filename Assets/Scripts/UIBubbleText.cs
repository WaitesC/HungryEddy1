using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBubbleText : MonoBehaviour
{
    public float speedTextWritter;
    public AudioClip typingSound;
    public string message;


    private Text messageText;
    private void Awake()
    {
        messageText = transform.Find("message").Find("messageText").GetComponent<Text>();
        //Application.targetFrameRate = 3;
    }
    private void Start() 
    {
        TextWriter.AddWriter_Static(messageText, message, 0.15f, true);
    }

}
