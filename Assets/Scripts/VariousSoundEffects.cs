using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariousSoundEffects : MonoBehaviour
{
    public AudioSource source;
    //sounds
    public AudioClip coinSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "SmallCoin")
        {
            //source.PlayOneShot(coinSound, 0.3f);





            //or gameObject.SetActive(false);
        }
    }
}
