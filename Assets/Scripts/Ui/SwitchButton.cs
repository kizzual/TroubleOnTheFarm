using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButton : MonoBehaviour
{
    [SerializeField] private Text gold_earned_text;
    [SerializeField] private GameObject MergePanel;
    [SerializeField] Game_controller _controller;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Display_Gold_earned(int value)
    {
        gold_earned_text.text = value.ToString();
    }
    public void MergeOnOff()
    {
        if (MergePanel.activeSelf)
        {
            MergePanel.SetActive(false);
        }
        else
        {
            _controller.TutorialAnimation(false);
            MergePanel.SetActive(true);
        }
    }
}
