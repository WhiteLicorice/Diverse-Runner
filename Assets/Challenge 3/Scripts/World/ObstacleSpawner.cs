using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;

    private WaitForSeconds spawnInterval = new WaitForSeconds(6.0f);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstacles");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnObstacles()
    {   
        while (true) {
            int randomX = Random.Range(18, 28 + 1); //  x values that are to the right and outside camera view
            GameObject randomObstacle = obstacles[Random.Range(0, obstacles.Length)];

            Vector3 prefabPosition = randomObstacle.transform.position;
            Quaternion prefabRotation = randomObstacle.transform.rotation;

            Vector3 spawnPoint = new Vector3(randomX, prefabPosition.y, prefabPosition.z);

            Instantiate(randomObstacle, spawnPoint, prefabRotation);

            yield return spawnInterval;
        }  
    }
}
