using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{   
    [SerializeField] private GameObject backgroundPrefab;
    private GameObject background;
    //  Potato values from editor and are in no way programmatic... Magic numbers!
    private Vector3 initialBackgroundPosition = new Vector3(45f, 9.68f, 4.59f);
    private Vector3 appendBackgroundPosition = new Vector3(91.0f + 1.6633f - 0.36f, 9.68f, 4.59f);

    private float leftBoundary = -20.0f;

    // Start is called before the first frame update
    void Start()
    {
        //  Spawn first background and maintain reference so we can query its location
        background = Instantiate(backgroundPrefab, initialBackgroundPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (background.transform.position.x < leftBoundary)
        {
            //  If current background goes past the left boundary, spawn new background
            SpawnBackground();
        }
    }

    private void SpawnBackground()
    {
        background = Instantiate(backgroundPrefab, appendBackgroundPosition, Quaternion.identity);
    }
}
