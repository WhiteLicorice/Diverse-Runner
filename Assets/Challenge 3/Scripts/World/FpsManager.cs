using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Awake()
    {   
        //  Clamping my fps to 60 because the game is too fast uncapped for a sidescroller
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
