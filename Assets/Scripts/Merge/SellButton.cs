using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellButton : MonoBehaviour
{
    [SerializeField] private MergeTimeAnimation _Controller;
    [SerializeField] private Game_controller _gameController;
   
    public void Selling(int value)
    {
        _Controller.TurnOnParticle(value);
        if(_gameController.Day == 1)
        {
            Merge_Tutorial._instanse.SwitchAnimation();
        }
    }
}
