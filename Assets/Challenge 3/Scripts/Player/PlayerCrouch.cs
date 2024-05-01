using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{   
    private Animator animator;
    private SfxPlayer sfx;
    private PlayerObserver observer;
    [SerializeField] string crouchBool = "Crouch_b";    //  Crouching boolean name defined in animator
    private bool isCrouching = false;
    [SerializeField] private WaitForSeconds crouchDuration = new WaitForSeconds(3.0f);
    [SerializeField] private Collider topCollider;
    [SerializeField] private Collider bottomCollider;

    void Awake()
    {
        animator = GetComponent<Animator>();
        observer = GetComponent<PlayerObserver>();
        sfx = GameObject.FindGameObjectWithTag("SfxPlayer").GetComponent<SfxPlayer>();
        topCollider.enabled = true;
        bottomCollider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {   
        //  Crouch upon input, after consulting observer if the player can crouch
        if (Input.GetKeyDown(KeyCode.S) && !isCrouching && !observer.IsJumping() && !observer.IsThrowing() && !observer.IsDead())
        {   
            //sfx.PlayCrouchingSfx();
            sfx.StopRunningLoop();
            sfx.RandomCrouchVoice();
            StartCoroutine("Crouch");
        }
    }

    private IEnumerator Crouch()
    {   
        //  Start crouch here
        isCrouching = true;
        topCollider.enabled = false;
        animator.SetBool(crouchBool, true);

        //Debug.Log("Started Crouching");

        //  Keep crouching until this time elapses
        yield return crouchDuration;

        //Debug.Log("Finished Crouching");

        //  Stop crouching and end coroutine
        animator.SetBool(crouchBool, false);
        topCollider.enabled = true;
        isCrouching = false;
    }

    //  Internal method exposed to observer
    internal bool GetCrouchingState()
    {
        return isCrouching;
    }
    
}
