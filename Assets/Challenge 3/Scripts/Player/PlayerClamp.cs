using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClamp : MonoBehaviour
{

    private Quaternion initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {   
        //  Simply maintain the player's initial rotation across the game
        transform.rotation = initialRotation;
    }
}
