using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    public float time;
    

    public bool shakeCamera;
    [Range(0f, 1f)]
    public float duration;
    [Range(0f, 1f)]
    public float magnitude;


    void Start()
    {
        shakeCamera = false;

        //if(shakeCamera)
            //StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(duration,magnitude));
 
        //Destroy(gameObject, time);
    }

    void Update()
    {
        if (shakeCamera)
            StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(duration,magnitude));
    }


}
