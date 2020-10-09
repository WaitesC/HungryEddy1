using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    public float delta = 1.5f;  // Amount to move left and right from the start point
    public float speed = 2.0f;
    private Vector3 startPos;
    private Vector3 rightPos;
    private Vector3 leftPos;

    public SpriteRenderer spriteRenderer;

    void Start()
    {
        startPos = transform.position;
        rightPos.x = startPos.x + delta;
        leftPos.x = startPos.x - delta;
    }

    void Update()
    {
        Vector3 v = startPos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;

        if (Mathf.Abs(transform.position.x - rightPos.x) < 0.1) 
        {
            spriteRenderer.flipX = true;
        }

        if (Mathf.Abs(transform.position.x - leftPos.x) < 0.1) 
        {
            spriteRenderer.flipX = false;
        }
    }
}
