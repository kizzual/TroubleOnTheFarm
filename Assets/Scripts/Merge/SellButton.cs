using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellButton : MonoBehaviour
{
    [SerializeField] private Game_controller _Controller;
   
    public void Selling(int value)
    {
        _Controller.GoldForSellRessources(value);
    }
}
