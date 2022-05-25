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
    [SerializeField] private Container container;
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
          /*  if(_controller.Day == 1)
            {
                Bust_tutorial._instance.SwitchTutorial();
            }*/
        }
        else
        {
            _controller.TutorialAnimation(false);
          
            if (_controller.Day == 1 && _controller.time_Bust_count == 0 )
            {
                container.inGameTutorial.StartMergeTutor(true);
            }
            else
            {
                MergePanel.SetActive(true);
            }
        }
    }
}
