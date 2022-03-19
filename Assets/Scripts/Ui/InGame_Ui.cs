using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InGame_Ui : MonoBehaviour
{
    [SerializeField] private Text DayTimer_text;
    [SerializeField] private Slider DayTime_Slider;

   
   
    public void Display_Day_timer( float seconds, int day_length)
    {
        TimeSpan ts = TimeSpan.FromSeconds(seconds);
        Display_time_slider(seconds, day_length);

        if (ts.Minutes != 0)
        {
            if (ts.Seconds >= 10)
            {
                DayTimer_text.text = "0" + ts.Minutes + ":" + ts.Seconds;
            }
            else
            {
                DayTimer_text.text = "0" + ts.Minutes + ":" + "0" + ts.Seconds;

            }
        }
        else if (ts.Minutes == 0)
        {
            if (ts.Seconds >= 10)
            {
                DayTimer_text.text = "00" + ":" + ts.Seconds;
            }
            else
            {
                DayTimer_text.text = "0" + ts.Minutes + ":" + "0" + ts.Seconds;
                DayTimer_text.text = "00" + ":" +"0"+ ts.Seconds;
            }
        }

    }
    private void Display_time_slider(float seconds,int day_length)
    {
        DayTime_Slider.maxValue = day_length;
        DayTime_Slider.value = day_length - (day_length - seconds);
    }
}
