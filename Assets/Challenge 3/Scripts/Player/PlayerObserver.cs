using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  Apply observer pattern to reduce spaghetti
public class PlayerObserver : MonoBehaviour
{
    private PlayerCrouch crouchState;
    private PlayerJump jumpState;
    private PlayerRun runState;
    private PlayerThrow throwState;
    private PlayerDeath deathState;
    private Vector3 spawnPosition;

    private PlayerPickup consumableState;

    void Awake()
    {
        crouchState = GetComponent<PlayerCrouch>();
        jumpState = GetComponent<PlayerJump>();
        runState = GetComponent<PlayerRun>();
        throwState = GetComponent<PlayerThrow>();
        deathState = GetComponent<PlayerDeath>();
        consumableState = GetComponent<PlayerPickup>();
        spawnPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //  pass
    }

    public bool IsCrouching()
    {
        return crouchState.GetCrouchingState();
    }

    public bool IsJumping()
    {
        return jumpState.GetAirborneState();
    }

    public bool IsRunning()
    {
        return runState.GetRunningState();
    }

    public bool IsThrowing()
    {
        return throwState.GetThrowingState();
    }

    public bool IsDead()
    {
        return deathState.GetDeathState();
    }

    public bool HasConsumable()
    {
        return consumableState.GetConsumableStatus();
    }

    public Vector3 PlayerPosition()
    {
        return transform.position;
    }

    public Vector3 PlayerSpawnPosition()
    {
        return spawnPosition;
    }

}
