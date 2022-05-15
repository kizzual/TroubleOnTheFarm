using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public static SoundController _instance;
    public Container container;
    public List<Dogs_Patroling> dogs;
    public AudioSource _audioSource;
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioClip buttonStartDay;

    [SerializeField] private AudioClip SoundOn;
    [SerializeField] private AudioClip SoundOff;
    [SerializeField] private AudioClip Buy;
    [SerializeField] private AudioClip MoneyEnded;
    [SerializeField] private AudioClip Fear;
    [SerializeField] private AudioClip Merge;

    void Awake()
    {
        _instance = this;
        if (PlayerPrefs.HasKey("SoundOn"))
        {
            if (PlayerPrefs.GetInt("SoundOn") == 1)
            {
                _audioSource.enabled = true;
            }
            else
            {
                _audioSource.enabled = false;
            }
        }
        else
        {
            _audioSource.enabled = true;
        }
    }

    public void Merging()
    {
        _audioSource.PlayOneShot(Merge);
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
    public void SoundStatus(bool isOn)
    {
        if(isOn)
        {
            _audioSource.mute = false;
            container.Chicken_paddock.SoundStatus(true);
            container.Cow_paddock.SoundStatus(true);
            container.Sheep_paddock.SoundStatus(true);
            container.Horse_paddock.SoundStatus(true);
            container.Pig_paddock.SoundStatus(true);
            container.Goat_paddock.SoundStatus(true);
            container.Goose_paddock.SoundStatus(true);
            foreach (var item in dogs)
            {
                item.SoundIsOn = true;
            }
        }
        else
        {
            _audioSource.mute = true;
            container.Chicken_paddock.SoundStatus(false);
            container.Cow_paddock.SoundStatus(false);
            container.Sheep_paddock.SoundStatus(false);
            container.Horse_paddock.SoundStatus(false);
            container.Pig_paddock.SoundStatus(false);
            container.Goat_paddock.SoundStatus(false);
            container.Goose_paddock.SoundStatus(false);
            foreach (var item in dogs)
            {
                item.SoundIsOn = false;
            }
        }
    }
}
