using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInGame : MonoBehaviour
{
    [SerializeField] private Game_controller gameController;
    public bool isPaddock;  
    public enum Type
    {
        Goose,
        Goat,
        Ostrich,
        Pig,
        Cow,
        Horse,
        Sheep,
        Chicken
    }
    public Type type;

    private void Start()
    {
 
    }
    public void BuyAnimal()
    {

        if (!isPaddock)
        {
            gameController.BuyAnimal(type);
        }
        else if (isPaddock)
        {
            gameController.BuePaddock(type);
          
        }
    }

}
