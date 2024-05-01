using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonPower : ConsumablePower
{   
    private Rigidbody rb;
    private Animator animator;
    private PlayerObserver observer;
    [SerializeField] private float jumpForce = 10;
    private SfxPlayer sfx;
    [SerializeField] private string jumpTrigger = "Jump_trig";


    void Awake()
    {
        observer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerObserver>();
        sfx = GameObject.FindGameObjectWithTag("SfxPlayer").GetComponent<SfxPlayer>();
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (observer.IsJumping() && Input.GetKeyDown(KeyCode.Space)) {
            SecondJump();
        }
    }

    void SecondJump()
    {   
        //  Reset vertical velocity to zero, to prevent downward velocity from cancelling out double jump in edge cases
        animator.SetTrigger(jumpTrigger);
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        sfx.RandomJumpVoice();
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        Destroy(gameObject);
    }
}
