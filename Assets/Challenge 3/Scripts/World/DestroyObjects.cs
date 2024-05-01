using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{   
    private GameObject[] availableConsumables;

    // Start is called before the first frame update
    void Start()
    {
        availableConsumables = GameObject.FindGameObjectWithTag("GenericManagers").GetComponent<ConsumableSpawner>().AvailableConsumables();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {   
        foreach (GameObject consumable in availableConsumables) {
            if (other.gameObject.CompareTag(consumable.tag)) {
                //Debug.Log("Pickup initiated!");
                Destroy(other.gameObject);
                break;
            }
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
        }
    }
}
