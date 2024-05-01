using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;

public class BombPower : ConsumablePower
{
    private PlayerObserver observer;
    private ParticleFactory particle;
    private new Collider collider;
    private SfxPlayer sfx;
    private ConsumableFollow cf;
    private Vector3 initialPosition;
    [SerializeField] private float bombSpeed = 10f;
    [SerializeField] private float explosionRadius = 3.0f;
    [SerializeField] private GameObject[] consumables;
    private Vector3 initialOffset = new Vector3 (1.5f, 2.0f, 0f);
    private float smoothness = 0.1f;
    private bool isBombThrown = false;
    private bool isBombSfxPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        observer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerObserver>();
        sfx = GameObject.FindGameObjectWithTag("SfxPlayer").GetComponent<SfxPlayer>();
        cf = GetComponent<ConsumableFollow>();
        collider = GetComponent<Collider>();
        consumables = GameObject.FindGameObjectWithTag("GenericManagers").GetComponent<ConsumableSpawner>().AvailableConsumables();
        particle = GameObject.FindGameObjectWithTag("ParticlePlayer").GetComponent<ParticleFactory>();
        initialPosition = observer.PlayerSpawnPosition() + initialOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if(observer.IsThrowing()) {
            cf.enabled = false;
            PositionBomb();
            Invoke("MoveBomb", 0.75f);
        }

        if (isBombThrown) {
            transform.Translate(bombSpeed * Vector3.right * Time.deltaTime, Space.World);
        }
        
    }

    void PositionBomb()
    {   
        if (!isBombSfxPlayed) {
            sfx.PlayJumpingSfx();
            isBombSfxPlayed = true;
        }
        transform.position = Vector3.Lerp(transform.position, initialPosition, smoothness);
    }

    void MoveBomb() {
        isBombThrown = true;
        collider.enabled = true;
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) {
            Explode();
        }

        foreach (GameObject consumable in consumables) {
            if (other.gameObject.CompareTag(consumable.tag)) {
                Explode();
                break;
            }
        }
    }

    void Explode() {
        //  Handle sfx and gfx
        sfx.PlayExplosionSfx();
        ParticleSystem explosion = particle.ExplosionParticle(transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        explosion.Play();

        //  Query colliders within the explosion radius
        Collider[] destroyedColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        
        //  Colliders are successfully being detected
        // foreach(var collider in destroyedColliders) {
        //     Debug.Log($"{collider.gameObject.name} is nearby");
        // }
        
        //  Destroy colliders that are "Obstacles" or in "Consumables"
        foreach (Collider collider in destroyedColliders) {
            if (collider.CompareTag("Obstacle")) {
                Destroy(collider.gameObject);
            }
            //  Check if the collider belongs to a consumable
            foreach (GameObject consumable in consumables) {
                if (collider.gameObject.CompareTag(consumable.tag)) {
                    Destroy(collider.gameObject);
                    break;
                }
            }
        }
        
        //  Simply destroy the bomb
        Destroy(gameObject);

    }


}
