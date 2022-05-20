using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButton : MonoBehaviour
{
    [SerializeField] private Text gold_earned_text;
    [SerializeField] private GameObject MergePanel;
    [SerializeField] Game_controller _controller;
    [SerializeField] GameObject merge_tutorial;
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
           /* if (_controller.Day == 1)
            {
                merge_tutorial.SetActive(true);
            }*/
        }
    }
}
