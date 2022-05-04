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
    public Player Goose_prefab;
    public Player Goat_prefab;
    public Player Ostrich_prefab;
    public Player pig_prefab;
    public Player Cow_prefab;
    public Player horse_prefab;
    public Player Sheep_prefab;
    public Player Chicken_prefab;

    [Header("UI")]
    public Result_ui Result_ui;
    public Finish_Ui Finish_ui;
    public InGame_Ui InGame_ui;
    public Manager_UI Manager_ui;
    public Inventory_container Inventory_ui;
    

    public StartDayAnimPanel startDayAnim;

    [Header("Panel")]
    public GameObject Ingame_panel;    
    public Manager_panel Manager_panel;

    [Header("Transfrom")]
    public Transform AnimalsParrent;
    public Transform zone_to_walk;
    public List<RandomPoint> RandomPoints;

    [Header("input")]
    public InputDetect inputMouse;

    [Header("ScriptableObjects")]
    public AnimalPrice animal_price;
    public Max_animals max_animals;
    public PaddockPrice PaddockPrice;
    public Busters_price busters_price;

    [Header("ScriptableObjects")]
    public SoundController _soundController;

}
