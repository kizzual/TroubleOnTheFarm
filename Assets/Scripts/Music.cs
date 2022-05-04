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
    [SerializeField] private AudioClip WolfSound;

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
        _audioSource.loop = true;
        _audioSource.clip = DayIsActive;
        _audioSource.Play();

      
    }
    public void NightIsOn()
    {
        _audioSource.Stop();
        _audioSource.loop = true;
        _audioSource.clip = NightIsActive;
        _audioSource.Play();
    }
    public void DayIsFinished()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(FinishDay);
    }
    public void Wolf()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(WolfSound);
    }
}
