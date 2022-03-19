using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Manager_panel : MonoBehaviour
{
    [Header("AnimalPrice")]
    [SerializeField] private TextMeshPro Goose_price_text;
    [SerializeField] private TextMeshPro Goat_price_text;
    [SerializeField] private TextMeshPro Ostrich_price_text;
    [SerializeField] private TextMeshPro Pig_price_text;
    [SerializeField] private TextMeshPro Cow_price_text;
    [SerializeField] private TextMeshPro Horse_price_text;
    [SerializeField] private TextMeshPro Sheep_price_text;
    [SerializeField] private TextMeshPro Chicken_price_text;

    [Header("PaddockPprice")]
    [SerializeField] private TextMeshPro Goose_paddock_price_text;
    [SerializeField] private TextMeshPro Goat_paddock_price_text;
    [SerializeField] private TextMeshPro Ostrich_paddock_price_text;
    [SerializeField] private TextMeshPro Pig_paddock_price_text;
    [SerializeField] private TextMeshPro Cow_paddock_price_text;
    [SerializeField] private TextMeshPro Horse_paddock_price_text;
    [SerializeField] private TextMeshPro Sheep_paddock_price_text;
    [SerializeField] private TextMeshPro Chicken_paddock_price_text;

    [Header("AnimalCount")]
    [SerializeField] private List<TextMeshPro> Goose_count_text;
    [SerializeField] private List<TextMeshPro> Goat_count_text;
    [SerializeField] private List<TextMeshPro> Ostrich_count_text;
    [SerializeField] private List<TextMeshPro> Pig_count_text;
    [SerializeField] private List<TextMeshPro> Cow_count_text;
    [SerializeField] private List<TextMeshPro> Horse_count_text;
    [SerializeField] private List<TextMeshPro> Sheep_count_text;
    [SerializeField] private List<TextMeshPro> Chicken_count_text;

    [SerializeField] private DisplayShopImage Goose_Panel;
    [SerializeField] private DisplayShopImage Goat_Panel;
    [SerializeField] private DisplayShopImage Ostrich_Panel;
    [SerializeField] private DisplayShopImage Pig_Panel;
    [SerializeField] private DisplayShopImage Cow_Panel;
    [SerializeField] private DisplayShopImage Horse_Panel;
    [SerializeField] private DisplayShopImage Sheep_Panel;
    [SerializeField] private DisplayShopImage Chicken_Panel;

    [SerializeField] private int Goose_count;
    [SerializeField] private int Goat_count;
    [SerializeField] private int Ostrich_count;
    [SerializeField] private int Pig_count;
    [SerializeField] private int Cow_count;
    [SerializeField] private int Horse_count;
    [SerializeField] private int Sheep_count;
    [SerializeField] private int Chicken_count;

    [SerializeField] AnimalPrice animalPrice;
    [SerializeField] Max_animals animalMax;
    [SerializeField] PaddockPrice paddocPrice;

    public void AnimalsCount(int goose, int goat, int ostrich, int pig, int cow, int horse,int sheep, int chicken)
    {
        Goose_count = goose;
        Goat_count = goat;
        Ostrich_count = ostrich;
        Pig_count = pig;
        Cow_count = cow;
        Horse_count = horse;
        Sheep_count = sheep;
        Chicken_count = chicken;
    }

    public void DisplayManagerPanel(AnimalPaddock paddoc)
    {
        if(paddoc.type == AnimalPaddock.Type.Goose)
        {
            if(paddoc.isActive)
            {
                if (Goose_count < animalMax.Goose)
                {
                    Goose_Panel.BuyAnimal();
                    Goose_price_text.text = animalPrice.Goose.ToString();
                    foreach (var text in Goose_count_text)
                    {
                        text.text = Goose_count.ToString() + "/" + animalMax.Goose.ToString();
                    }
                }
                else if (Goose_count >= animalMax.Goose)
                {
                    Goose_Panel.MaxAnimal();
                    foreach (var text in Goose_count_text)
                    {
                        text.text = Goose_count.ToString() + "/" + animalMax.Goose.ToString();
                    }
                }
            }
            else
            {
                Goose_Panel.Buy_Paddock();
                Goose_paddock_price_text.text = "$" + paddocPrice.Goose.ToString();
            }
        }
        if (paddoc.type == AnimalPaddock.Type.Goat)
        {
            if (paddoc.isActive)
            {
                if (Goat_count < animalMax.Goat)
                {
                    Goat_Panel.BuyAnimal();
                    Goat_price_text.text = animalPrice.Goat.ToString();
                    foreach (var text in Goat_count_text)
                    {
                        text.text = Goat_count.ToString() + "/" + animalMax.Goat.ToString();
                    }
                }
                else if (Goat_count >= animalMax.Goat)
                {
                    Goat_Panel.MaxAnimal();
                    foreach (var text in Goat_count_text)
                    {
                        text.text = Goat_count.ToString() + "/" + animalMax.Goat.ToString();
                    }
                }
            }
            else
            {
                Goat_Panel.Buy_Paddock();
                Goat_paddock_price_text.text = "$" + paddocPrice.Goat.ToString();
            }
        }
        if (paddoc.type == AnimalPaddock.Type.Ostrich)
        {
            if (paddoc.isActive)
            {
                if (Ostrich_count < animalMax.Ostrich)
                {
                    Ostrich_Panel.BuyAnimal();
                    Ostrich_price_text.text = animalPrice.Ostrich.ToString();
                    foreach (var text in Ostrich_count_text)
                    {
                        text.text = Ostrich_count.ToString() + "/" + animalMax.Ostrich.ToString();
                    }
                }
                else if (Ostrich_count >= animalMax.Ostrich)
                {
                    Ostrich_Panel.MaxAnimal();
                    foreach (var text in Ostrich_count_text)
                    {
                        text.text = Ostrich_count.ToString() + "/" + animalMax.Ostrich.ToString();
                    }
                }
            }
            else
            {
                Ostrich_Panel.Buy_Paddock();
                Ostrich_paddock_price_text.text = "$" + paddocPrice.Ostrich.ToString();
            }
        }
        if (paddoc.type == AnimalPaddock.Type.Pig)
        {
            if (paddoc.isActive)
            {
                if (Pig_count < animalMax.Pig)
                {
                    Pig_Panel.BuyAnimal();
                    Pig_price_text.text = animalPrice.Pig.ToString();
                    foreach (var text in Pig_count_text)
                    {
                        text.text = Pig_count.ToString() + "/" + animalMax.Pig.ToString();
                    }
                }
                else if (Pig_count >= animalMax.Pig)
                {
                    Pig_Panel.MaxAnimal();
                    foreach (var text in Pig_count_text)
                    {
                        text.text = Pig_count.ToString() + "/" + animalMax.Pig.ToString();
                    }
                }
            }
            else
            {
                Pig_Panel.Buy_Paddock();
                Pig_paddock_price_text.text = "$" + paddocPrice.Pig.ToString();
            }
        }
        if (paddoc.type == AnimalPaddock.Type.Cow)
        {
            if (paddoc.isActive)
            {
                if (Cow_count < animalMax.Cow)
                {
                    Cow_Panel.BuyAnimal();
                    Cow_price_text.text = animalPrice.Cow.ToString();
                    foreach (var text in Cow_count_text)
                    {
                        text.text = Cow_count.ToString() + "/" + animalMax.Cow.ToString();
                    }
                }
                else if (Cow_count >= animalMax.Cow)
                {
                    Cow_Panel.MaxAnimal();
                    foreach (var text in Cow_count_text)
                    {
                        text.text = Cow_count.ToString() + "/" + animalMax.Cow.ToString();
                    }
                }
            }
            else
            {
                Cow_Panel.Buy_Paddock();
                Cow_paddock_price_text.text = "$" + paddocPrice.Cow.ToString();
            }
        }
        if (paddoc.type == AnimalPaddock.Type.Horse)
        {
            if (paddoc.isActive)
            {
                if (Horse_count < animalMax.Horse)
                {
                    Horse_Panel.BuyAnimal();
                    Horse_price_text.text = animalPrice.Horse.ToString();
                    foreach (var text in Horse_count_text)
                    {
                        text.text = Horse_count.ToString() + "/" + animalMax.Horse.ToString();
                    }
                }
                else if (Horse_count >= animalMax.Horse)
                {
                    Horse_Panel.MaxAnimal();
                    foreach (var text in Horse_count_text)
                    {
                        text.text = Horse_count.ToString() + "/" + animalMax.Horse.ToString();
                    }
                }
            }
            else
            {
                Horse_Panel.Buy_Paddock();
                Horse_paddock_price_text.text = "$" + paddocPrice.Horse.ToString();
            }
        }
        if (paddoc.type == AnimalPaddock.Type.Sheep)
        {
            if (paddoc.isActive)
            {
                if (Sheep_count < animalMax.Sheep)
                {
                    Sheep_Panel.BuyAnimal();
                    Sheep_price_text.text = animalPrice.Sheep.ToString();
                    foreach (var text in Sheep_count_text)
                    {
                        text.text = Sheep_count.ToString() + "/" + animalMax.Sheep.ToString();
                    }
                }
                else if (Sheep_count >= animalMax.Sheep)
                {
                    Sheep_Panel.MaxAnimal();
                    foreach (var text in Sheep_count_text)
                    {
                        text.text = Sheep_count.ToString() + "/" + animalMax.Sheep.ToString();
                    }
                }
            }
            else
            {
                Sheep_Panel.Buy_Paddock();
                Sheep_paddock_price_text.text = "$" + paddocPrice.Sheep.ToString();
            }
        }
        if (paddoc.type == AnimalPaddock.Type.Chicken)
        {
            if (paddoc.isActive)
            {
                if (Chicken_count < animalMax.Chicken)
                {
                    Chicken_Panel.BuyAnimal();
                    Chicken_price_text.text = animalPrice.Chicken.ToString();
                    foreach (var text in Chicken_count_text)
                    {
                        text.text = Chicken_count.ToString() + "/" + animalMax.Chicken.ToString();
                    }
                }
                else if (Chicken_count >= animalMax.Chicken)
                {
                    Chicken_Panel.MaxAnimal();
                    foreach (var text in Chicken_count_text)
                    {
                        text.text = Chicken_count.ToString() + "/" + animalMax.Chicken.ToString();
                    }
                }
            }
            else
            {
                Chicken_Panel.Buy_Paddock();
                Chicken_paddock_price_text.text = "$" + paddocPrice.Chicken.ToString();
            }
        }






    }
    public void ResetAll()
    {
        PlayerPrefs.DeleteAll(); 
    }
}
