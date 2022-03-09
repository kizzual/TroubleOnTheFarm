using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Game_controller : MonoBehaviour
{
    [SerializeField] private Container container;

    [SerializeField] private float radius_walk_zone;

    [SerializeField] private int Goose_count;
    [SerializeField] private int Goat_count;
    [SerializeField] private int Ostrich_count;
    [SerializeField] private int Pig_count;
    [SerializeField] private int Cow_count;
    [SerializeField] private int Horse_count;
    [SerializeField] private int Sheep_count;
    [SerializeField] private int Chicken_count;

    [SerializeField] private float Day_length;

    private bool DayIsActive = false;
    private float timer;

    void Awake()
    {
        SpawnAnimals();
    }
    private void Update()
    {
        DayActive();
    }
    private void SpawnAnimals()
    {
        if (container.Goose_paddock.isActive)
        {
            container.Goose_paddock.SpawnAnimals(container.Goose_prefab, Goose_count, container.zone_to_walk, radius_walk_zone, container.AnimalsParrent);
        }
        if (container.Goat_paddock.isActive)
        {
            container.Goat_paddock.SpawnAnimals(container.Goat_prefab, Goat_count, container.zone_to_walk, radius_walk_zone, container.AnimalsParrent);
        }
        if (container.Ostrich_paddock.isActive)
        {
            container.Ostrich_paddock.SpawnAnimals(container.Ostrich_prefab, Ostrich_count, container.zone_to_walk, radius_walk_zone, container.AnimalsParrent);
        }
        if (container.Pig_paddock.isActive)
        {
            container.Pig_paddock.SpawnAnimals(container.pig_prefab, Pig_count, container.zone_to_walk, radius_walk_zone, container.AnimalsParrent);
        }
        if (container.Cow_paddock.isActive)
        {
            container.Cow_paddock.SpawnAnimals(container.Cow_prefab, Cow_count, container.zone_to_walk, radius_walk_zone, container.AnimalsParrent);
        }
        if (container.Horse_paddock.isActive)
        {
            container.Horse_paddock.SpawnAnimals(container.horse_prefab, Horse_count, container.zone_to_walk, radius_walk_zone, container.AnimalsParrent);
        }
        if (container.Sheep_paddock.isActive)
        {
            container.Sheep_paddock.SpawnAnimals(container.Sheep_prefab, Sheep_count, container.zone_to_walk, radius_walk_zone, container.AnimalsParrent);
        }
        if (container.Chicken_paddock.isActive)
        {
            container.Chicken_paddock.SpawnAnimals(container.Chicken_prefab, Chicken_count, container.zone_to_walk, radius_walk_zone, container.AnimalsParrent);
        }
    }

    private void Gold_Earned() // вывод заработанного количества денег на экран
    {
        container.Result_ui.Gold_earned(Goose_count, Goat_count, Ostrich_count, Pig_count, Cow_count, Horse_count, Sheep_count, Chicken_count);
    }

    private void Scoring() // сьедаем скот и перемещаем в загон
    {
        container.Goose_paddock.Day_result();
        container.Goat_paddock.Day_result();
        container.Ostrich_paddock.Day_result();
        container.Pig_paddock.Day_result();
        container.Cow_paddock.Day_result();
        container.Horse_paddock.Day_result();
        container.Sheep_paddock.Day_result();
        container.Chicken_paddock.Day_result();
    }

    private void DisplayScoreDay() // ѕровер€ем количество каждого скота
    {
        Goose_count = container.Goose_paddock.In_Side_animals.Count;
        Goat_count = container.Goat_paddock.In_Side_animals.Count;
        Ostrich_count = container.Ostrich_paddock.In_Side_animals.Count;
        Pig_count = container.Pig_paddock.In_Side_animals.Count;
        Cow_count = container.Cow_paddock.In_Side_animals.Count;
        Horse_count = container.Horse_paddock.In_Side_animals.Count;
        Sheep_count = container.Sheep_paddock.In_Side_animals.Count;
        Chicken_count = container.Chicken_paddock.In_Side_animals.Count;
    }
    private void DayActive()
    {
        if(DayIsActive)
        {
            timer += Time.deltaTime;
            if(timer >= Day_length)
            {
                DayIsActive = false;
                timer = 0;
                Scoring();
                DisplayScoreDay();
                //вызов финиш панели
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(container.zone_to_walk.position, radius_walk_zone);
    }

}
