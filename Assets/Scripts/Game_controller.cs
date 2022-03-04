using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Game_controller : MonoBehaviour
{
    [SerializeField] private int pig_count;
    [SerializeField] private int horse_count;

    [Header("Paddocks")]
    [SerializeField] private AnimalPaddock Pig_paddock;
    [SerializeField] private AnimalPaddock Horse_paddock;

    [Header("Prefabs")]
    [SerializeField] private GameObject pig_prefab;
    [SerializeField] private GameObject horse_prefab;


    [SerializeField] private Transform AnimalsParrent;
    [SerializeField] private Transform zone_to_walk;
    void Awake()
    {
        SpawnAnimals();
    }


    void Update()
    {
        
    }
    private void SpawnAnimals()
    {
        if(CheckPaddock(Pig_paddock))
        {
            for (int i = 1; i < pig_count; i++)
            {
                Animal go = Instantiate(pig_prefab, Pig_paddock.SpawnPos(), Quaternion.identity, AnimalsParrent).GetComponent<Animal>();
                go.SetPriority(i);
                go.zone_to_walk = zone_to_walk;
            }
        }
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
}
