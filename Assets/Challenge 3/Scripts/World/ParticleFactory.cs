using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFactory : MonoBehaviour
{
   [SerializeField] private GameObject runningParticle;
   [SerializeField] private GameObject explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject RunningParticle(Vector3 position, Quaternion rotation)
    {
        return Instantiate(runningParticle, position, rotation);
    }

    public GameObject ExplosionParticle(Vector3 position, Quaternion rotation)
    {
        return Instantiate(explosionParticle, position, rotation);
    }
}
