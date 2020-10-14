using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlateController : MonoBehaviour
{
    public Animator triggerAnimation;
    public Animator myAnimation;

    public string triggeredAnimationNameOnEnter;
    public string triggeredAnimationNameOnExit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        myAnimation.Play("TriggerPlate_Pressed");
        triggerAnimation.Play(triggeredAnimationNameOnEnter);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        myAnimation.Play("TriggerPlate_Idle");
        triggerAnimation.Play(triggeredAnimationNameOnExit);

    }
}
