using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

 //   public static SoundController _instance;

    public  AudioSource _audioSource;
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioClip buttonStartDay;

    [SerializeField] private AudioClip SoundOn;
    [SerializeField] private AudioClip SoundOff;
    [SerializeField] private AudioClip Buy;
    [SerializeField] private AudioClip MoneyEnded;
    [SerializeField] private AudioClip Fear;

    void Start()
    {
        _audioSource.GetComponent<AudioSource>();
    }


    public void ClickButton()
    {   
        _audioSource.PlayOneShot(buttonClick);
    } 
    public void ClickStartDayButton()
    {
        _audioSource.PlayOneShot(buttonStartDay);
    }
    public void TurnSoundOn()
    {
        _audioSource.PlayOneShot(SoundOn);
    }
    public void TurnSoundOff()
    {
        _audioSource.PlayOneShot(SoundOff);
    }
    public void BuySometing()
    {
        _audioSource.PlayOneShot(Buy);
    }
    public void NotEnoughMoney()
    {
        _audioSource.PlayOneShot(MoneyEnded);
    }
    public void Fearing()
    {
        _audioSource.PlayOneShot(Fear);
    }
}
