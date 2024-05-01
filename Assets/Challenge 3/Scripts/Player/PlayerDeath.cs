using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{   
    private bool isDead = false;
    [SerializeField] private string deathBool = "Death_b";
    private PlayerObserver observer;
    private Animator animator;
    private Rigidbody rb;
    [SerializeField] private float minRagdollForce = 5.0f;
    [SerializeField] private float maxRagdollForce = 50.0f;

    private SfxPlayer sfx;
    private ParticleFactory particle;

    void Awake()
    {
        observer = GetComponent<PlayerObserver>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        sfx = GameObject.FindGameObjectWithTag("SfxPlayer").GetComponent<SfxPlayer>();
        particle = GameObject.FindGameObjectWithTag("ParticlePlayer").GetComponent<ParticleFactory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {   
        //  Avoid dying twice (people die when they are killed!)
        if (other.gameObject.CompareTag("Obstacle") && !isDead) {
            Die();
        }

        //  If player is dead, then keep ragdolling on collision
        if (other.gameObject.CompareTag("Obstacle") && isDead) {
            Ragdoll();
        }
    }

    //  Internal method exposed to observer
    internal bool GetDeathState()
    {
        return isDead;
    }

    void Die()
    {
        animator.SetBool(deathBool, true);
        isDead = true;
        Ragdoll();
        //Debug.Log("Dead!");
        //Time.timeScale = 0;
        //  Call an abstracted Reset() function somewhere
    }

    void Ragdoll()
    {
        //  Use managers to instantiate effects
        particle.ExplosionParticle(transform.position, Quaternion.identity).GetComponent<ParticleSystem>().Play();
        sfx.PlayExplosionSfx();
        //  Apply some random naive ragdoll
        Vector3 ragdollForce = (Vector3.right + Vector3.up + Vector3.back) * Random.Range(minRagdollForce, maxRagdollForce);
        rb.AddForce(ragdollForce, ForceMode.Impulse);
    }

    
}
