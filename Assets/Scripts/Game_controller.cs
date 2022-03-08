using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Game_controller : MonoBehaviour
{
    [SerializeField] private int Goose_count;
    [SerializeField] private int Goat_count;
    [SerializeField] private int Ostrich_count;
    [SerializeField] private int Pig_count;
    [SerializeField] private int Cow_count;
    [SerializeField] private int horse_count;
    [SerializeField] private int Sheep_count;
    [SerializeField] private int Chicken_count;

    [Header("Paddocks")]
    [SerializeField] private AnimalPaddock Goose_paddock;
    [SerializeField] private AnimalPaddock Goat_paddock;
    [SerializeField] private AnimalPaddock Ostrich_paddock;
    [SerializeField] private AnimalPaddock Pig_paddock;
    [SerializeField] private AnimalPaddock Cow_paddock;
    [SerializeField] private AnimalPaddock Horse_paddock;
    [SerializeField] private AnimalPaddock Sheep_paddock;
    [SerializeField] private AnimalPaddock Chicken_paddock;


    [Header("Prefabs")]
    [SerializeField] private Animal Goose_prefab;
    [SerializeField] private Animal Goat_prefab;
    [SerializeField] private Animal Ostrich_prefab;
    [SerializeField] private Animal pig_prefab;
    [SerializeField] private Animal Cow_prefab;
    [SerializeField] private Animal horse_prefab;
    [SerializeField] private Animal Sheep_prefab;
    [SerializeField] private Animal Chicken_prefab;


    [SerializeField] private Transform AnimalsParrent;
    [SerializeField] private Transform zone_to_walk;
    [SerializeField] private float radius_walk_zone;
    void Awake()
    {
        SpawnAnimals();
    }


    void Update()
    {
    }
    private void SpawnAnimals()
    {
        Goose_paddock.SpawnAnimals(Goose_prefab, Goose_count, zone_to_walk, radius_walk_zone, AnimalsParrent);
        Goat_paddock.SpawnAnimals(Goat_prefab, Goat_count, zone_to_walk, radius_walk_zone, AnimalsParrent);
        Ostrich_paddock.SpawnAnimals(Ostrich_prefab, Ostrich_count, zone_to_walk, radius_walk_zone, AnimalsParrent);
        Pig_paddock.SpawnAnimals(pig_prefab, Pig_count, zone_to_walk, radius_walk_zone, AnimalsParrent);
        Cow_paddock.SpawnAnimals(Cow_prefab, Cow_count, zone_to_walk, radius_walk_zone, AnimalsParrent);
        Horse_paddock.SpawnAnimals(horse_prefab, horse_count, zone_to_walk, radius_walk_zone, AnimalsParrent);
        Sheep_paddock.SpawnAnimals(Sheep_prefab, Sheep_count, zone_to_walk, radius_walk_zone, AnimalsParrent);
        Chicken_paddock.SpawnAnimals(Chicken_prefab, Chicken_count, zone_to_walk, radius_walk_zone, AnimalsParrent);

    }
    private bool CheckPaddock(AnimalPaddock paddock)
    {
        if(paddock.gameObject.activeSelf)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(zone_to_walk.position, radius_walk_zone);

    }
}
