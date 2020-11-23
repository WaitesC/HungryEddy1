using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePopUp : MonoBehaviour
{
    // Create a Score Pop Up
    public static ScorePopUp Create(Vector3 position, int smallCoinValue)
    {
        Transform scorePopUpTransform = Instantiate(GameAssets.i.ScorePopUp, position, Quaternion.identity);
        
        ScorePopUp scorePopUp = scorePopUpTransform.GetComponent<ScorePopUp>();
        scorePopUp.Setup(smallCoinValue);

    return scorePopUp;
    }

    private static int sortingOrder;
    
    private const float DISAPPEAR_TIMER_MAX = 1f;
    
    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;
    private Vector3 moveVector;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(int smallCoinValue)
    {
        textMesh.SetText(smallCoinValue.ToString());
        //textMesh.fontSize = 50;
        textColor = textMesh.color;
        disappearTimer = DISAPPEAR_TIMER_MAX;

        // To keep any new pop ups on top of the earlier ones
        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;

        // moveVector contains both direction and speed
        moveVector = new Vector3(.7f, 1) * 60f;
    }

    // Move our pop up upwards at a constant speed
    private void Update()
    {
        transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * 8f * Time.deltaTime;

        // if above half of our MAX constant
        if (disappearTimer > DISAPPEAR_TIMER_MAX *.5f)
        {
            //First half of the pop up lifetime
            float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;

        }

        else
        {
            // Second half of the pop up lifetime
            float decreaseScaleAmount = 1f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }
        
        // Score disappear after a certain time
        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            // Start disappearing
            float disappearSpeed = 3f;
            // Text color a (alpha)
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }

        }
    }
}
