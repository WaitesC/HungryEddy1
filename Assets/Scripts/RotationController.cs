using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public float speedRotate;

    public bool rotateClockwise;

    int rotationDir;

   

    // Update is called once per frame
    void Update()
    {
        if (rotateClockwise == true)
            rotationDir = -1;
        if (rotateClockwise == false)
            rotationDir = 1;

        transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime * rotationDir);

    }
}
