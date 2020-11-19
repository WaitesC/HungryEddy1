using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBubbleText : MonoBehaviour
{
    [SerializeField] private TextWriter textWriter;
    private Text messageText;
    private void Awake()
    {
        messageText = transform.Find("message").Find("messageText").GetComponent<Text>();
        //Application.targetFrameRate = 3;
    }
    private void Start() 
    {
        //textWriter.AddWriter(messageText, "Hello World", 1f);
        textWriter.AddWriter(messageText, "Hello, I'm Eddy", 1f, true);
    }

}
