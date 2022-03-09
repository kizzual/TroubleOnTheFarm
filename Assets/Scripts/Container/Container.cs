using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    [Header("Paddocks")]
    public AnimalPaddock Goose_paddock;
    public AnimalPaddock Goat_paddock;
    public AnimalPaddock Ostrich_paddock;
    public AnimalPaddock Pig_paddock;
    public AnimalPaddock Cow_paddock;
    public AnimalPaddock Horse_paddock;
    public AnimalPaddock Sheep_paddock;
    public AnimalPaddock Chicken_paddock;

    [Header("Prefabs")]
    public Animal Goose_prefab;
    public Animal Goat_prefab;
    public Animal Ostrich_prefab;
    public Animal pig_prefab;
    public Animal Cow_prefab;
    public Animal horse_prefab;
    public Animal Sheep_prefab;
    public Animal Chicken_prefab;

    [Header("UI")]
    public Result_ui Result_ui;


    public Transform AnimalsParrent;
    public Transform zone_to_walk;
    
}
