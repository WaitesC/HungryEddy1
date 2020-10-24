using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {


            FindObjectOfType<GameManager>().EndLevel();
            FindObjectOfType<GameManager>().levelOver = true;


        }
    }
}
