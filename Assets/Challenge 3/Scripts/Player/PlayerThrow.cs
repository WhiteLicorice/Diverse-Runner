using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    private Animator animator;
    private PlayerObserver observer;

    private SfxPlayer sfx;
    private WaitForSeconds throwDuration = new WaitForSeconds(0.75f);
    private bool isThrowing = false;
    [SerializeField] private string throwAnimationName = "GrenadeThrow";    //  Name of throwing animation in animator

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        observer = GetComponent<PlayerObserver>();
        sfx = GameObject.FindGameObjectWithTag("SfxPlayer").GetComponent<SfxPlayer>();
    }

    // Update is called once per frame
    void Update()
    {   
        //  By design, this allows the player to play the throw animation even if they aren't holding a bomb
        if (Input.GetKeyDown(KeyCode.Space) && !isThrowing && !observer.IsCrouching() && !observer.IsJumping() && !observer.IsDead()) {
            sfx.RandomThrowVoice();
            StartCoroutine("Throw");
        }
    }

    // internal void ThrowConsumable () {
    //      StartCoroutine("Throw");
    // }

    private IEnumerator Throw()
    {   
        isThrowing = true;
        animator.Play(throwAnimationName);

        //Debug.Log("Started Throwing");

        //  Potato solution because Unity API is not the best at handling animation timings. Might need another game engine for better timings.
        yield return throwDuration;

        //yield await => animation.end
        //Debug.Log("Finished Throwing");

        isThrowing = false;
    }

    internal bool GetThrowingState()
    {
        return isThrowing;
    }
    
}
