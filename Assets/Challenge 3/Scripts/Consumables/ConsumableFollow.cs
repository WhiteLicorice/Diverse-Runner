using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableFollow : MonoBehaviour
{
    [SerializeField] private Vector3 topOffset = new Vector3(0, 7.0f, 0);
    [SerializeField] float smoothness = 0.1f;
    private Vector3 targetPosition;

    void Awake()
    {
        targetPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerObserver>().PlayerSpawnPosition() + topOffset;
    }

    // Start is called before the first frame update
    void Start()
    {   
        StartCoroutine("Follow");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Follow() {
        while (gameObject) {
            //  Interpolate the current position towards the target position so it's smoooooooooooth
            while (transform.position != targetPosition) {
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness);
                yield return null;
            }
            yield return null;
        }
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        StopAllCoroutines();
    }
    
}
