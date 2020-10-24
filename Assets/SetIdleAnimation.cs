using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetIdleAnimation : MonoBehaviour
{
    public Animator animator;
    public string idleState;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.Play(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
