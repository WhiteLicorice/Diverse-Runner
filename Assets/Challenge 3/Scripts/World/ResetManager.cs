using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class ResetManager : MonoBehaviour
{   
    private PlayerObserver playerObserver;

    private float resetBuffer = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerReference = GameObject.FindGameObjectWithTag("Player");
        if  (playerReference != null) {
            playerObserver = playerReference.GetComponent<PlayerObserver>();
            //Debug.Log("Player found!");
        } else {
            //Debug.Log("Could not find Player object!");
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (playerObserver.IsDead()) {
            Invoke("ResetScene", resetBuffer);
        }
    }

    private void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
