using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxPlayer : MonoBehaviour
{   
    [SerializeField] private GameObject cameraReference;
    [SerializeField] private AudioClip runningLoopSfx;
    [SerializeField] private AudioClip jumpingSfx;
    [SerializeField] private AudioClip crouchingSfx;
    [SerializeField] private AudioClip explosionSfx;
    [SerializeField] private AudioClip throwingSfx;
    [SerializeField] private AudioClip dingSfx;

    [SerializeField] private AudioSource oneShot;
    [SerializeField] private AudioSource looping;
    [SerializeField] private AudioSource voice;

    [SerializeField] private AudioClip[] jumpVoices;
    [SerializeField] private AudioClip[] crouchVoices;
    [SerializeField] private AudioClip[] throwVoices;
    [SerializeField] private AudioClip[] cashVoices;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = cameraReference.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRunningLoop()
    {   
        if (looping.clip != runningLoopSfx || !looping.isPlaying) {
            looping.clip = runningLoopSfx;
            looping.Play();
        }
    }

    public void StopRunningLoop()
    {
        looping.Stop();
    }

    public void PlayJumpingSfx()
    {
        Debug.Log("Jumping sound played!"); //  Sanity check because sfx is sometimes too soft relative to highs of the bgm
        oneShot.PlayOneShot(jumpingSfx);
    }

    public void PlayExplosionSfx()
    {
        oneShot.PlayOneShot(explosionSfx);
    }

    public void PlayThrowingSfx()
    {
        oneShot.PlayOneShot(throwingSfx);
    }

    public void PlayCrouchingSfx()
    {
        oneShot.PlayOneShot(crouchingSfx);
    }

     public void PlayDingSfx()
    {
        oneShot.PlayOneShot(dingSfx);
    }

    public void RandomJumpVoice()
    {
        AudioClip randomClip = jumpVoices[Random.Range(0, jumpVoices.Length)];
        voice.PlayOneShot(randomClip);
    }

    public void RandomCrouchVoice()
    {
        AudioClip randomClip = crouchVoices[Random.Range(0, crouchVoices.Length)];
        voice.PlayOneShot(randomClip);
    }

    public void RandomThrowVoice()
    {
        AudioClip randomClip = throwVoices[Random.Range(0, throwVoices.Length)];
        voice.PlayOneShot(randomClip);
    }

      public void RandomCashVoice()
    {
        AudioClip randomClip = cashVoices[Random.Range(0, cashVoices.Length)];
        voice.PlayOneShot(randomClip);
    }


}
