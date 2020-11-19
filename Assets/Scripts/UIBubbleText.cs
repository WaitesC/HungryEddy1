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
        
        //Application.targetFrameRate = 3;
    }
    private void Start() 
    {
        messageText = transform.Find("message").Find("messageText").GetComponent<Text>();

        TextWriter.AddWriter_Static(messageText, message, 0.15f, true);
    }

}
