using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result_ui : MonoBehaviour
{
    
    [SerializeField] private Text incomePerCount_Chicken_text;
    [SerializeField] private Text incomePerCount_Goose_text;
    [SerializeField] private Text incomePerCount_Goat_text;
    [SerializeField] private Text incomePerCount_Pig_text;
    [SerializeField] private Text incomePerCount_Sheep_text;
    [SerializeField] private Text incomePerCount_Cow_text;
    [SerializeField] private Text incomePerCount_Ostrich_text;
    [SerializeField] private Text incomePerCount_Horse_text;


    [SerializeField] private Text stayAlive_Chicken_text;
    [SerializeField] private Text stayAlive_Goose_text;
    [SerializeField] private Text stayAlive_Goat_text;
    [SerializeField] private Text stayAlive_Pig_text;
    [SerializeField] private Text stayAlive_Sheep_text;
    [SerializeField] private Text stayAlive_Cow_text;
    [SerializeField] private Text stayAlive_Ostrich_text;
    [SerializeField] private Text stayAlive_Horse_text;

    [SerializeField] private Text summ_Chicken_text;
    [SerializeField] private Text summ_Goose_text;
    [SerializeField] private Text summ_Goat_text;
    [SerializeField] private Text summ_Pig_text;
    [SerializeField] private Text summ_Sheep_text;
    [SerializeField] private Text summ_Cow_text;
    [SerializeField] private Text summ_Ostrich_text;
    [SerializeField] private Text summ_Horse_text;

    [SerializeField] private Text summ_total_text;


    private int summ;

    [SerializeField] private AnimalIncome income_settings;
    void Start()
    {
        StartInitialize();
    }
    private void StartInitialize()
    {
        incomePerCount_Chicken_text.text = "$" + income_settings.incomePerCount_Chicken_text.ToString();
        incomePerCount_Goose_text.text = "$" + income_settings.incomePerCount_Goose_text.ToString();
        incomePerCount_Goat_text.text = "$" + income_settings.incomePerCount_Goat_text.ToString();
        incomePerCount_Pig_text.text = "$" + income_settings.incomePerCount_Pig_text.ToString();
        incomePerCount_Sheep_text.text = "$" + income_settings.incomePerCount_Sheep_text.ToString();
        incomePerCount_Cow_text.text = "$" + income_settings.incomePerCount_Cow_text.ToString();
        incomePerCount_Ostrich_text.text = "$" + income_settings.incomePerCount_Ostrich_text.ToString();
        incomePerCount_Horse_text.text = "$" + income_settings.incomePerCount_Horse_text.ToString();
    }

     public void Gold_earned(int Goose, int Goat, int Ostrich, int Pig, int Cow, int Horse, int Sheep, int Chicken)
    {
        int totalSumm = 0;
        totalSumm += Goose * income_settings.incomePerCount_Goose_text;
        stayAlive_Goose_text.text = "x" + Goose.ToString();
        summ_Goose_text.text = "$" + (Goose * income_settings.incomePerCount_Goose_text).ToString();

        totalSumm += Goat * income_settings.incomePerCount_Goat_text;
        stayAlive_Goat_text.text = "x" + Goat.ToString();
        summ_Goat_text.text = "$" + (Goat * income_settings.incomePerCount_Goat_text).ToString();

        totalSumm += Ostrich * income_settings.incomePerCount_Ostrich_text;
        stayAlive_Ostrich_text.text = "x" + Ostrich.ToString();
        summ_Ostrich_text.text = "$" + (Ostrich * income_settings.incomePerCount_Ostrich_text).ToString();

        totalSumm += Pig * income_settings.incomePerCount_Pig_text;
        stayAlive_Pig_text.text = "x" + Pig.ToString();
        summ_Pig_text.text = "$" + (Pig * income_settings.incomePerCount_Pig_text).ToString();

        totalSumm += Cow * income_settings.incomePerCount_Cow_text;
        stayAlive_Cow_text.text = "x" + Cow.ToString();
        summ_Cow_text.text = "$" + (Cow * income_settings.incomePerCount_Cow_text).ToString();

        totalSumm += Horse * income_settings.incomePerCount_Horse_text;
        stayAlive_Horse_text.text = "x" + Horse.ToString();
        summ_Horse_text.text = "$" + (Horse * income_settings.incomePerCount_Horse_text).ToString();

        totalSumm += Sheep * income_settings.incomePerCount_Sheep_text;
        stayAlive_Sheep_text.text = "x" + Sheep.ToString();
        summ_Sheep_text.text = "$" + (Sheep * income_settings.incomePerCount_Sheep_text).ToString();

        totalSumm += Chicken * income_settings.incomePerCount_Chicken_text;
        stayAlive_Chicken_text.text = "x" + Chicken.ToString();
        summ_Chicken_text.text = "$" + (Chicken * income_settings.incomePerCount_Chicken_text).ToString();


        summ_total_text.text = totalSumm.ToString();
    }



}
