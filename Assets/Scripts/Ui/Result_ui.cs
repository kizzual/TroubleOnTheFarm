using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result_ui : MonoBehaviour
{
    
    [SerializeField] private Text income_Chicken_text;
    [SerializeField] private Text income_Goose_text;
    [SerializeField] private Text income_Goat_text;
    [SerializeField] private Text income_Pig_text;
    [SerializeField] private Text income_Sheep_text;
    [SerializeField] private Text income_Cow_text;
    [SerializeField] private Text incomeP_Ostrich_text;
    [SerializeField] private Text income_Horse_text;

    [SerializeField] private Game_controller _game_Controller;

    [SerializeField] private Text dayText;
    void Start()
    {

    }

     public void Gold_earned(int Goose, int Goat, int Ostrich, int Pig, int Cow, int Horse, int Sheep, int Chicken)
    {


        income_Goose_text.text = Goose.ToString();

        income_Goat_text.text = Goat.ToString();

        incomeP_Ostrich_text.text = Ostrich.ToString();

        income_Pig_text.text = Pig.ToString();

        income_Cow_text.text = Cow.ToString();

        income_Horse_text.text = Horse.ToString();

        income_Sheep_text.text = Sheep.ToString();

        income_Chicken_text.text = Chicken.ToString();

        _game_Controller.GetResources(Goose, Goat, Ostrich, Pig, Cow, Horse, Sheep, Chicken);
    }

    public void DisplayCurrentDay(int value)
    {
        dayText.text = "Day " + value.ToString() + " Results";
    }


}
