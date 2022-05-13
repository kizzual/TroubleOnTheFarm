using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Merge", menuName = "Merge/Merge", order = 1)]
public class TypeOfObjects : ScriptableObject
{
    [SerializeField] Type Type;

    #region Name
    [Header("Name")]
    [SerializeField] public string Chicken_1_name;
    [Header("Name")]
    [SerializeField] public string Chicken_2_name;
    [Header("Name")]
    [SerializeField] public string Chicken_3_name;
    [Header("Name")]
    [SerializeField] public string Chicken_4_name;

    [Header("Name")]
    [SerializeField] public string Goose_1_name;
    [Header("Name")]
    [SerializeField] public string Goose_2_name;
    [Header("Name")]
    [SerializeField] public string Goose_3_name;
    [Header("Name")]
    [SerializeField] public string Goose_4_name;

    [Header("Name")]
    [SerializeField] public string Goat_1_name;
    [Header("Name")]
    [SerializeField] public string Goat_2_name;
    [Header("Name")]
    [SerializeField] public string Goat_3_name;
    [Header("Name")]
    [SerializeField] public string Goat_4_name;

    [Header("Name")]
    [SerializeField] public string Ostrich_1_name;
    [Header("Name")]
    [SerializeField] public string Ostrich_2_name;
    [Header("Name")]
    [SerializeField] public string Ostrich_3_name;
    [Header("Name")]
    [SerializeField] public string Ostrich_4_name;

    [Header("Name")]
    [SerializeField] public string Sheep_1_name;
    [Header("Name")]
    [SerializeField] public string Sheep_2_name;
    [Header("Name")]
    [SerializeField] public string Sheep_3_name;
    [Header("Name")]
    [SerializeField] public string Sheep_4_name;

    [Header("Name")]
    [SerializeField] public string Pig_1_name;
    [Header("Name")]
    [SerializeField] public string Pig_2_name;
    [Header("Name")]
    [SerializeField] public string Pig_3_name;
    [Header("Name")]
    [SerializeField] public string Pig_4_name;

    [Header("Name")]
    [SerializeField] public string Cow_1_name;
    [Header("Name")]
    [SerializeField] public string Cow_2_name;
    [Header("Name")]
    [SerializeField] public string Cow_3_name;
    [Header("Name")]
    [SerializeField] public string Cow_4_name;

    [Header("Name")]
    [SerializeField] public string Horse_1_name;
    [Header("Name")]
    [SerializeField] public string Horse_2_name;
    [Header("Name")]
    [SerializeField] public string Horse_3_name;
    [Header("Name")]
    [SerializeField] public string Horse_4_name;
    #endregion
    #region Price;
    [Header("Price")]
    [SerializeField] public int Chicken_1_price;
    [Header("Price")]
    [SerializeField] public int Chicken_2_price;
    [Header("Price")]
    [SerializeField] public int Chicken_3_price;
    [Header("Price")]
    [SerializeField] public int Chicken_4_price;

    [Header("Price")]
    [SerializeField] public int Goose_1_price;
    [Header("Price")]
    [SerializeField] public int Goose_2_price;
    [Header("Price")]
    [SerializeField] public int Goose_3_price;
    [Header("Price")]
    [SerializeField] public int Goose_4_price;

    [Header("Price")]
    [SerializeField] public int Goat_1_price;
    [Header("Price")]
    [SerializeField] public int Goat_2_price;
    [Header("Price")]
    [SerializeField] public int Goat_3_price;
    [Header("Price")]
    [SerializeField] public int Goat_4_price;

    [Header("Price")]
    [SerializeField] public int Ostrich_1_price;
    [Header("Price")]
    [SerializeField] public int Ostrich_2_price;
    [Header("Price")]
    [SerializeField] public int Ostrich_3_price;
    [Header("Price")]
    [SerializeField] public int Ostrich_4_price;

    [Header("Price")]
    [SerializeField] public int Sheep_1_price;
    [Header("Price")]
    [SerializeField] public int Sheep_2_price;
    [Header("Price")]
    [SerializeField] public int Sheep_3_price;
    [Header("Price")]
    [SerializeField] public int Sheep_4_price;

    [Header("Price")]
    [SerializeField] public int Pig_1_price;
    [Header("Price")]
    [SerializeField] public int Pig_2_price;
    [Header("Price")]
    [SerializeField] public int Pig_3_price;
    [Header("Price")]
    [SerializeField] public int Pig_4_price;

    [Header("Price")]
    [SerializeField] public int Cow_1_price;
    [Header("Price")]
    [SerializeField] public int Cow_2_price;
    [Header("Price")]
    [SerializeField] public int Cow_3_price;
    [Header("Price")]
    [SerializeField] public int Cow_4_price;

    [Header("Price")]
    [SerializeField] public int Horse_1_price;
    [Header("Price")]
    [SerializeField] public int Horse_2_price;
    [Header("Price")]
    [SerializeField] public int Horse_3_price;
    [Header("Price")]
    [SerializeField] public int Horse_4_price;
    #endregion
    #region Sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Chicken_1_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Chicken_2_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Chicken_3_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Chicken_4_sprite;

    [Header("Sprite")]
    [SerializeField] public Sprite Goose_1_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Goose_2_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Goose_3_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Goose_4_sprite;

    [Header("Sprite")]
    [SerializeField] public Sprite Goat_1_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Goat_2_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Goat_3_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Goat_4_sprite;

    [Header("Sprite")]
    [SerializeField] public Sprite Ostrich_1_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Ostrich_2_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Ostrich_3_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Ostrich_4_sprite;

    [Header("Sprite")]
    [SerializeField] public Sprite Sheep_1_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Sheep_2_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Sheep_3_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Sheep_4_sprite;

    [Header("Sprite")]
    [SerializeField] public Sprite Pig_1_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Pig_2_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Pig_3_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Pig_4_sprite;

    [Header("Sprite")]
    [SerializeField] public Sprite Cow_1_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Cow_2_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Cow_3_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Cow_4_sprite;

    [Header("Sprite")]
    [SerializeField] public Sprite Horse_1_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Horse_2_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Horse_3_sprite;
    [Header("Sprite")]
    [SerializeField] public Sprite Horse_4_sprite;
    #endregion
}
public enum Type
{
    Chicken,
    Goose,
    Goat,
    Ostrich,
    Sheep,
    Pig,
    Cow,
    Horse,
}


