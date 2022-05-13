using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButton : MonoBehaviour
{
    [SerializeField] private Text gold_earned_text;
    [SerializeField] private GameObject MergePanel;

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
            MergePanel.SetActive(true);
        }
    }
}
