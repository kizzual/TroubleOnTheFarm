using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellButton : MonoBehaviour
{
    [SerializeField] private MergeTimeAnimation _Controller;
   
    public void Selling(int value)
    {
        _Controller.TurnOnParticle(value);
    }
}
