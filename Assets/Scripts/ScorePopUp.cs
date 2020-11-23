using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePopUp : MonoBehaviour
{
    public static ScorePopUp Create(Vector3 position, int scoreAmount)
    {
        Transform scorePopUpTransform = Instantiate(GameAssets.i.ScorePopUp, position, Quaternion.identity);
        
        ScorePopUp scorePopUp = scorePopUpTransform.GetComponent<ScorePopUp>();
        scorePopUp.Setup(scoreAmount);

    return scorePopUp;
    }

    private TextMeshPro textMesh;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(int scoreAmount)
    {
        textMesh.SetText(scoreAmount.ToString());
    }
}
