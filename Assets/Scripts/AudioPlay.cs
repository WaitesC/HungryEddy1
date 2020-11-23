using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public AudioSource audioDataHappy;
    public AudioSource audioDataSad;
    public AudioSource audioDataDie;

    public bool happy, sad, die;
    void HappySound()
    {
        audioDataHappy.Play(0);
    }
    
    void SadSound()
    {
        audioDataSad.Play(0);
    }
    
    void DieSound()
    {

        audioDataDie.loop = false;
        audioDataDie.Play(0);
    }

    void Update()
    {
        if (happy)
            HappySound();

        if (sad)
            SadSound();

        if (die)
            DieSound();
    }
}
