using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    private static bool isGravityInitialized = false;
    private static Vector3 originalGravity;
    private static Vector3 gameGravity;
    private float gravityFactor = 1.5f;

    // Awake is called when the script instance is being loaded
    void Awake()
    { 
        if (!isGravityInitialized) {
            //  Tweak gravity settings and save original gravity
            originalGravity = Physics.gravity;
            gameGravity = originalGravity * gravityFactor;
            Physics.gravity = gameGravity;
            isGravityInitialized = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
