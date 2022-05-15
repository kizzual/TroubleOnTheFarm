using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MergeUI : MonoBehaviour
{
    [SerializeField] private CreateObject _createObject;
    [SerializeField] private Game_controller _gameController;

    [SerializeField] private Text Goose_res_text;
    [SerializeField] private Text Goat_res_text;
    [SerializeField] private Text Ostrich_res_text;
    [SerializeField] private Text Pig_res_text;
    [SerializeField] private Text Cow_res_text;
    [SerializeField] private Text Horse_res_text;
    [SerializeField] private Text Sheep_res_text;
    [SerializeField] private Text Chicken_res_text; 

    [SerializeField] private int Goose_res_count;
    [SerializeField] private int Goat_res_count;
    [SerializeField] private int Ostrich_res_count;
    [SerializeField] private int Pig_res_count;
    [SerializeField] private int Cow_res_count;
    [SerializeField] private int Horse_res_count;
    [SerializeField] private int Sheep_res_count;
    [SerializeField] private int Chicken_res_count;


    void Start()
    {
        
    }


    void Update()
    {
        
    }
    public void CheckRessourcesCout()
    {
        Goose_res_count = Save.Goose_res_Get();
        Goat_res_count = Save.Goat_res_Get();
        Ostrich_res_count = Save.Ostrich_count_Get();
        Pig_res_count = Save.Pig_res_Get();
        Cow_res_count = Save.Cow_res_Get();
        Horse_res_count = Save.Horse_res_Get();
        Chicken_res_count = Save.Chicken_res_Get();
        Sheep_res_count = Save.Sheep_res_Get();
        DisplayRessources();
    }

    public void DisplayRessources()
    {
        Goose_res_text.text = Goose_res_count.ToString();
        Goat_res_text.text = Goat_res_count.ToString();
        Ostrich_res_text.text = Ostrich_res_count.ToString();
        Pig_res_text.text = Pig_res_count.ToString();
        Cow_res_text.text = Cow_res_count.ToString();
        Horse_res_text.text = Horse_res_count.ToString();
        Sheep_res_text.text = Sheep_res_count.ToString();
        Chicken_res_text.text = Chicken_res_count.ToString();
    }
    public void ClickButton(int value)
    {
        if(value == 1 && Goose_res_count > 0)
        {
            _createObject.CreateObjectInPanel(value);
            Goose_res_count--;
        }
        else if (value == 2 && Goat_res_count > 0)
        {
            _createObject.CreateObjectInPanel(value);
            Goat_res_count--;
        }
        else if (value == 3 && Ostrich_res_count > 0)
        {
            _createObject.CreateObjectInPanel(value);
            Ostrich_res_count--;
        }
        else if (value == 4 && Pig_res_count > 0)
        {
            _createObject.CreateObjectInPanel(value);
            Pig_res_count--;
        }
        else if (value == 5 && Cow_res_count > 0)
        {
            _createObject.CreateObjectInPanel(value);
            Cow_res_count--;
        }
        else if (value == 6 && Horse_res_count > 0)
        {
            _createObject.CreateObjectInPanel(value);
            Horse_res_count--;
        }
        else if (value == 7 && Sheep_res_count > 0)
        {
            _createObject.CreateObjectInPanel(value);
            Sheep_res_count--;
        }
        else if (value == 8 && Chicken_res_count > 0)
        {
            _createObject.CreateObjectInPanel(value);
            Chicken_res_count--;
        }
        DisplayRessources();
    }
    public void CloseMergePanel()
    {
        _createObject.SaveObjects();
        Save.Save_Goose_res(Goose_res_count);
        Save.Save_Goat_res(Goat_res_count);
        Save.Save_Ostrich_rest(Ostrich_res_count);
        Save.Save_Pig_res(Pig_res_count);
        Save.Save_Cow_res(Cow_res_count);
        Save.Save_Horse_res(Horse_res_count);
        Save.Save_Chicken_res(Chicken_res_count);
        Save.Save_Sheep_res(Sheep_res_count);
        _gameController.CheckSave();
        _gameController.SaveAll();
    }

}
