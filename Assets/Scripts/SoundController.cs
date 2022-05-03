using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public static SoundController _instance;

    public  AudioSource _audioSource;
    [SerializeField] private AudioClip buttonClick;

    void Start()
    {
        _audioSource.GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
    public void ClickButton()
    {
        _audioSource.PlayOneShot(buttonClick);
    }
}
