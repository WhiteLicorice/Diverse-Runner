using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
    public float spinSpeed;

    // Update is called once per frame
    void Update()
    {
        float rotationAmount = spinSpeed * Time.deltaTime;

        //  Calculate the rotation quaternion
        Quaternion deltaRotation = Quaternion.Euler(0f, rotationAmount, 0f);

        transform.rotation *= deltaRotation;
    }
}
