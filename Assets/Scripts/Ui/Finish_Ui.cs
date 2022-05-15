using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish_Ui : MonoBehaviour
{
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LosePanel;

    [SerializeField] private Text Die_Chicken_text;
    [SerializeField] private Text Die_Goose_text;
    [SerializeField] private Text Die_Goat_text;
    [SerializeField] private Text Die_Pig_text;
    [SerializeField] private Text Die_Sheep_text;
    [SerializeField] private Text Die_Cow_text;
    [SerializeField] private Text Die_Ostrich_text;
    [SerializeField] private Text Die_Horse_text;

    [SerializeField] private List<Text> DayFinished;


    void Start()
    {

    }


    public void WinDay()
    {
        
        LosePanel.SetActive(false);
        WinPanel.SetActive(true);
    }

    public void LoseDay(int Goose, int Goat, int Ostrich, int Pig, int Cow, int Horse, int Sheep, int Chicken)
    {
        

        LosePanel.SetActive(true);
        WinPanel.SetActive(false);

        if (Goose > 0) Die_Goose_text.text = "-" + Goose.ToString();
        else Die_Goose_text.text =  Goose.ToString();
        if (Goat > 0) Die_Goat_text.text = "-" + Goat.ToString();
        else Die_Goat_text.text = Goat.ToString();
        if (Ostrich > 0) Die_Ostrich_text.text = "-" + Ostrich.ToString();
        else Die_Ostrich_text.text = Ostrich.ToString();
        if (Pig > 0) Die_Pig_text.text = "-" + Pig.ToString();
        else Die_Pig_text.text = Pig.ToString();
        if (Cow > 0) Die_Cow_text.text = "-" + Cow.ToString();
        else Die_Cow_text.text = Cow.ToString();
        if (Horse > 0) Die_Horse_text.text = "-" + Horse.ToString();
        else Die_Horse_text.text = Horse.ToString();
        if (Sheep > 0) Die_Sheep_text.text = "-" + Sheep.ToString();
        else Die_Sheep_text.text = Sheep.ToString();
        if (Chicken > 0) Die_Chicken_text.text = "-" + Chicken.ToString();
        else Die_Chicken_text.text = Chicken.ToString();
    }
    public void DisplaDayFinished(int value)
    {
        foreach (var item in DayFinished)
        {
            item.text = value.ToString();
        }
    }
}

