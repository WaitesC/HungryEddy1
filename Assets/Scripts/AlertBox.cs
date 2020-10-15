using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertBox : MonoBehaviour
{
    public Transform caterpillar;

    public SpriteRenderer caterpillarSpriteRenderer;

    public Animator animator;

    bool runRight;
    bool runLeft;

    public bool escapeRight;
    public bool escapeLeft;

    public float fleeSpeed;

    bool escapeTime;

    // Start is called before the first frame update
    void Start()
    {
        escapeTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (escapeRight == true) 
            Right();
        if(escapeLeft == true)
            Left();
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        animator.Play("Caterpillar_Purple_Alert");

        escapeTime = true;

        if(escapeTime && escapeLeft)
            caterpillarSpriteRenderer.flipX = true;

    }

    void Right()
    {
        if (escapeTime)
            caterpillar.transform.Translate(Vector3.right * Time.deltaTime * fleeSpeed);
    }
    
    void Left()
    {
        if (escapeTime)
            caterpillar.transform.Translate(Vector3.left * Time.deltaTime * fleeSpeed);
    }
}
