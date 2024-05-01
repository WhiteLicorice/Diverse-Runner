using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{   
    private Animator animator;
    private PlayerObserver observer;
    private bool isRunning = true;
    [SerializeField] private string runningBool = "Running_b"; //   Running boolean name defined in the animator
    private ParticleFactory particle;
    private GameObject _runningParticle;
    private SfxPlayer sfx;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        observer = GetComponent<PlayerObserver>();
        particle = GameObject.FindGameObjectWithTag("ParticlePlayer").GetComponent<ParticleFactory>();
        sfx = GameObject.FindGameObjectWithTag("SfxPlayer").GetComponent<SfxPlayer>();
    }

    // Update is called once per frame
    void Update()
    {   
        //  If observer says that the player is dead, then stop running
        if (observer.IsDead()) {
            Destroy(_runningParticle);
            sfx.StopRunningLoop();
            isRunning = false;
            animator.SetBool(runningBool, false);
        }
    }

    void OnCollisionExit(Collision other)
    {   
        //  Upon exiting collision with "Ground", then stop running
        if (other.gameObject.CompareTag("Ground")) {
            if (_runningParticle != null) {
                Destroy(_runningParticle);
            }
            sfx.StopRunningLoop();
            isRunning = false;
            animator.SetBool(runningBool, false);
        }
    }

    void OnCollisionEnter(Collision other)
    {   
        //  Upon entering collision with "Ground" and observer says that the player isn't dead, then start running
        if (other.gameObject.CompareTag("Ground") && !observer.IsDead()) {
            sfx.StartRunningLoop();
            isRunning = true;
            animator.SetBool(runningBool, true);
            if (_runningParticle == null) {
                _runningParticle = particle.RunningParticle(transform.position, Quaternion.identity);
            }
        }
    }

    //  Internal method exposed to observer
    internal bool GetRunningState()
    {
        return isRunning;
    }
}
