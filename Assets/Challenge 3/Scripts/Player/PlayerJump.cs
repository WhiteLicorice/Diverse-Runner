using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    private Rigidbody rb;
    private PlayerObserver observer;
    [SerializeField] private float jumpForce = 10;
    private bool isAirborne = false;
    private Animator animator;
    [SerializeField] private string jumpTrigger = "Jump_trig";
    private SfxPlayer sfx;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        observer = GetComponent<PlayerObserver>();
        sfx = GameObject.FindGameObjectWithTag("SfxPlayer").GetComponent<SfxPlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isAirborne && !observer.IsCrouching() && !observer.IsThrowing() && !observer.IsDead())
        {
            Jump();
        }
    }

    void Jump()
    {   
        //Debug.Log("Jumped");
        sfx.PlayJumpingSfx();
        isAirborne = true;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        animator.SetTrigger(jumpTrigger);
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")) {
            isAirborne = false;
        }
    }

    //  Internal getter
    internal bool GetAirborneState()
    {
        return isAirborne;
    }
}
