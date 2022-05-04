using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music _instance;
    public AudioSource _audioSource;

    [SerializeField] private AudioClip DayIsActive;
    [SerializeField] private AudioClip NightIsActive;
    [SerializeField] private AudioClip FinishDay;

    void Start()
    {
        _instance = this;
    }


    void Update()
    {
        
    }
    public void DayIsOn()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(DayIsActive);
    }
    public void NightIsOn()
    {
        _audioSource.Stop();

        _audioSource.PlayOneShot(NightIsActive);
    }
    public void DayIsFinished()
    {
        _audioSource.Stop();

        _audioSource.PlayOneShot(FinishDay);
    }
}
