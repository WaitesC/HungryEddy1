using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TutorialVideoEndController : MonoBehaviour
{
    public GameObject tutorialInbetweenPage;

    public VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //tutorialInbetweenPage = GameObject.Find("Tutorial InbetweenPage");

        //videoPlayer = GetComponent<VideoPlayer>();
    }

    void Awake()
    {
        videoPlayer.loopPointReached += EndReached;


    }

    // Update is called once per frame
    void Update()
    {
    }

    void EndReached(VideoPlayer vp)
    {
        tutorialInbetweenPage.SetActive(true);
    }
}
