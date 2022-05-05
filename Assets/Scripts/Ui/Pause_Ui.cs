using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Ui : MonoBehaviour
{
    private bool sound_bool;
    private bool musicd_bool;
    private int graphic;

    public SoundController _soundController;

    [SerializeField] private GameObject Pause;

    [Header("Sound")]
    [SerializeField] private Text sound;

    [Header("Music")]
    [SerializeField] private Text music;

    [Header("Graphic Image")]
    [SerializeField] private Image Low;
    [SerializeField] private Image Medium;
    [SerializeField] private Image High;
    public Container Container;
    void Start()
    {
        sound_bool = Save.AnimalsSoundOn_Get();
        if (sound_bool)
        {
            sound.text = "ON";

        }
        else
        {
            sound.text = "OFF";
        }
        musicd_bool = Save.MusicOn_Get();
        if (musicd_bool)
        {
            music.text = "ON";
        }
        else
        {
            music.text = "OFF";
        }
        graphic = Save.Graphic_Get();
        SetQuality(graphic);

    }


    void Update()
    {

    }
    public void SoundOnOff()
    {
        if (sound_bool)
        {
            _soundController.TurnSoundOff();
            _soundController.SoundStatus(false);
            sound_bool = false;
            sound.text = "OFF";
            Save.SoundSave(sound_bool);
        }
        else
        {
            _soundController.TurnSoundOn();
            _soundController.SoundStatus(true);
            sound_bool = true;
            sound.text = "ON";
            Save.SoundSave(sound_bool);
        }
    }
    public void MusicOnOff()
    {
        if (musicd_bool)
        {
            _soundController.TurnSoundOff();
            Music._instance.MusicStatus(false);
            musicd_bool = false;
            music.text = "OFF";
            Save.MusicSave(false);
        }
        else
        {
            _soundController.TurnSoundOn();
            Music._instance.MusicStatus(true);
            musicd_bool = true;
            music.text = "ON";
            Save.MusicSave(true);
        }
    }

    public void SetQuality(int value)
    {
        QualitySettings.SetQualityLevel(value);
        Save.GraphicSave(value);
        switch (value)
        {
            case 0:
                {
                    Low.gameObject.SetActive(true);
                    Medium.gameObject.SetActive(false);
                    High.gameObject.SetActive(false);
                    break;
                }
            case 1:
                {
                    Low.gameObject.SetActive(false);
                    Medium.gameObject.SetActive(true);
                    High.gameObject.SetActive(false);
                    break;
                }
            case 2:
                {
                    Low.gameObject.SetActive(false);
                    Medium.gameObject.SetActive(false);
                    High.gameObject.SetActive(true);
                    break;
                }
        }

    }

    public void PauseButton()
    {

        if (Pause.activeSelf)
        {
            Time.timeScale = 1;

            Pause.SetActive(false);
        }
        else
        {
            if(Container.inputMouse.InGame)
            {
                Time.timeScale = 0.0001f;
            }
            Pause.SetActive(true);
        }
    }

}
