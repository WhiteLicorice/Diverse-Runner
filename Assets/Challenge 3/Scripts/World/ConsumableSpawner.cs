using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ConsumableSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] consumables;

    private WaitForSeconds spawnInterval = new WaitForSeconds(6.0f);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnConsumables");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnConsumables()
    {   
        while (true) {
            int randomX = Random.Range(29, 38 + 1); //  x values that are to the right and outside camera view
            GameObject randomConsumable = consumables[Random.Range(0, consumables.Length)];

            Vector3 prefabPosition = randomConsumable.transform.position;
            Quaternion prefabRotation = randomConsumable.transform.rotation;

            Vector3 spawnPoint = new Vector3(randomX, prefabPosition.y, prefabPosition.z);

            Instantiate(randomConsumable, spawnPoint, prefabRotation);

            yield return spawnInterval;
        }  
    }

    public GameObject[] AvailableConsumables() {
        return consumables;
    }
}
