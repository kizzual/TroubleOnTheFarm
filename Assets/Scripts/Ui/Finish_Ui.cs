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
    [SerializeField] Container container;

    void Start()
    {

    }


    public void WinDay()
    {
        
        LosePanel.SetActive(false);
        WinPanel.SetActive(true);
        Die_Goose_text.text = container.Goose_paddock.In_Side_animals.Count.ToString() + "/" + container.Goose_paddock.animal_max_count.ToString();
        Die_Goat_text.text = container.Goat_paddock.In_Side_animals.Count.ToString() + "/" + container.Goat_paddock.animal_max_count.ToString();
        Die_Ostrich_text.text = container.Ostrich_paddock.In_Side_animals.Count.ToString() + "/" + container.Ostrich_paddock.animal_max_count.ToString();
        Die_Pig_text.text = container.Pig_paddock.In_Side_animals.Count.ToString() + "/" + container.Pig_paddock.animal_max_count.ToString();
        Die_Cow_text.text = container.Cow_paddock.In_Side_animals.Count.ToString() + "/" + container.Cow_paddock.animal_max_count.ToString();
        Die_Horse_text.text = container.Horse_paddock.In_Side_animals.Count.ToString() + "/" + container.Horse_paddock.animal_max_count.ToString();
        Die_Sheep_text.text = container.Sheep_paddock.In_Side_animals.Count.ToString() + "/" + container.Sheep_paddock.animal_max_count.ToString();
        Die_Chicken_text.text = container.Chicken_paddock.In_Side_animals.Count.ToString() + "/" + container.Chicken_paddock.animal_max_count.ToString();

    }

    public void LoseDay(int Goose, int Goat, int Ostrich, int Pig, int Cow, int Horse, int Sheep, int Chicken)
    {
        

        LosePanel.SetActive(true);
        WinPanel.SetActive(false);

        /* if (Goose > 0) Die_Goose_text.text = "-" + Goose.ToString();
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
         else Die_Chicken_text.text = Chicken.ToString();*/


        Die_Goose_text.text = container.Goose_paddock.In_Side_animals.Count.ToString() +  "/" + container.Goose_paddock.MaxAnimalsToDisplay.ToString();
        Die_Goat_text.text = container.Goat_paddock.In_Side_animals.Count.ToString() + "/" + container.Goat_paddock.MaxAnimalsToDisplay.ToString();
        Die_Ostrich_text.text = container.Ostrich_paddock.In_Side_animals.Count.ToString() + "/" + container.Ostrich_paddock.MaxAnimalsToDisplay.ToString();
        Die_Pig_text.text = container.Pig_paddock.In_Side_animals.Count.ToString() + "/" + container.Pig_paddock.MaxAnimalsToDisplay.ToString();
        Die_Cow_text.text = container.Cow_paddock.In_Side_animals.Count.ToString() + "/" + container.Cow_paddock.MaxAnimalsToDisplay.ToString();
        Die_Horse_text.text = container.Horse_paddock.In_Side_animals.Count.ToString() + "/" + container.Horse_paddock.MaxAnimalsToDisplay.ToString();
        Die_Sheep_text.text = container.Sheep_paddock.MaxAnimalsToDisplay.ToString() + "/" + container.Sheep_paddock.MaxAnimalsToDisplay.ToString();
        Die_Chicken_text.text = container.Chicken_paddock.In_Side_animals.Count.ToString() + "/" + container.Chicken_paddock.MaxAnimalsToDisplay.ToString();

    }
    public void DisplaDayFinished(int value)
    {
        foreach (var item in DayFinished)
        {
            item.text = value.ToString();
        }
    }
}

