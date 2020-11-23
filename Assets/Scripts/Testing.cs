using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private Transform ScorePopUp;
    
    private void Start()
    {
        Instantiate(ScorePopup, Vector3.zero, Quaternion.identity);
    }


}
