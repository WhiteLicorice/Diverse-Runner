using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  Apply strategy design pattern in implementing consumables to increase modularity
public class PlayerPickup : MonoBehaviour
{
    private GameObject[] availableConsumables;
    private GameObject currentConsumable;
    private bool isConsumableReady = false;

    void Awake()
    {
        availableConsumables = GameObject.FindGameObjectWithTag("GenericManagers").GetComponent<ConsumableSpawner>().AvailableConsumables();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentConsumable == null) {
            isConsumableReady = false;
        }
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (!isConsumableReady) {
            foreach (GameObject consumable in availableConsumables) {//  Can be optimized with a static hashtable on startup, but unnecessary rn
                //Debug.Log("Powerup collision!");
                //Debug.Log(consumable.tag);
                if (other.gameObject.CompareTag(consumable.tag) && other.gameObject.transform.parent == null) {
                    //Debug.Log("Pickup initiated!");
                    Pickup(other.gameObject);
                    break; // Exit the loop once a consumable is picked up
                }
            }
        }
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    // void OnCollisionEnter(Collision other)
    // {
    //     foreach (GameObject consumable in availableConsumables) {
    //         Debug.Log("Powerup collision!");
    //         Debug.Log(consumable.tag);
    //         if (other.gameObject.CompareTag(consumable.tag)) {
    //             Debug.Log("Pickup initiated!");
    //             Pickup(other.gameObject);
    //             break; // Exit the loop once a consumable is picked up
    //         }
    //     }
    // }

    void Pickup(GameObject consumable)
    {
        //Debug.Log("In pickup");
        if (currentConsumable != null)
        {
            Destroy(currentConsumable);
        }
        currentConsumable = consumable;
        
        //  Disable the collider of the consumable
        Collider consumableCollider = currentConsumable.GetComponent<Collider>();
        if (consumableCollider != null)
        {
            consumableCollider.enabled = false;
        }
        
        //  Disable movement script of the consumable
        MoveLeft movementScript = currentConsumable.GetComponent<MoveLeft>();
        if (movementScript != null)
        {
            movementScript.enabled = false;
        }

        //  Append the script that makes the consumable follow as a component
        currentConsumable.AddComponent<ConsumableFollow>();
        currentConsumable.transform.SetParent(transform);

        //  Enable the consumable power attached to the consumable once picked up
        ConsumablePower consumablePower = currentConsumable.GetComponent<ConsumablePower>();
        if (consumablePower != null)
        {
            consumablePower.enabled = true;
        }

        isConsumableReady = true;
    }

    internal bool GetConsumableStatus()
    {
        return isConsumableReady;
    }
}
