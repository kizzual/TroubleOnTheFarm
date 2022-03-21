using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AnimalPaddock : MonoBehaviour
{
    public bool isActive;
    [SerializeField] private Door door;
    [SerializeField] private float spawnRaduis;
//  [SerializeField] private Vector3 spawnRaduisCube;

    [SerializeField] TextMeshPro animals_count;
    private int animal_max_count;

    public enum Type
    {
        Goose,
        Goat,
        Ostrich,
        Pig,
        Cow,
        Horse,
        Sheep,
        Chicken
    }
    public Type type;

    public List<Animal> In_Side_animals;
    public List<Animal> Out_Side_animals;
    private bool firstSpawn = true;

    private int diedAnimals;
    void Awake()
    {
        CheckSave();
   //     door.Close_door();
    }
    private void Start()
    {
        DisplayAnimal_count();

      /*  if (isActive)
        {
            OpenGate();
        }*/
    }
    private void CheckSave()
    {
        if (type == Type.Goose)
        {
            if (PlayerPrefs.GetInt("Goose_paddock") == 1)
            {
                isActive = true;
            }
            else
            {
                isActive = false;
            }
        }
        if (type == Type.Goat)
        {
            if (PlayerPrefs.GetInt("Goat_paddock") == 1)
            {
                isActive = true;
            }
            else
            {
                isActive = false;
            }
        }
        if (type == Type.Ostrich)
        {
            if (PlayerPrefs.GetInt("Ostrich_paddock") == 1)
            {
                isActive = true;
            }
            else
            {
                isActive = false;
            }
        }
        if (type == Type.Pig)
        {
            if (PlayerPrefs.GetInt("Pig_paddock") == 1)
            {
                isActive = true;
            }
            else
            {
                isActive = false;
            }
        }
        if (type == Type.Cow)
        {
            if (PlayerPrefs.GetInt("Cow_paddock") == 1)
            {
                isActive = true;
            }
            else
            {
                isActive = false;
            }
        }
        if (type == Type.Horse)
        {
            if (PlayerPrefs.GetInt("Horse_paddock") == 1)
            {
                isActive = true;
            }
            else
            {
                isActive = false;
            }
        }
        if (type == Type.Sheep)
        {
            if (PlayerPrefs.GetInt("Sheep_paddock") == 1)
            {
                isActive = true;
            }
            else
            {
                isActive = false;
            }
        }
        if (type == Type.Chicken)
        {
            if (PlayerPrefs.GetInt("Chicken_paddock") == 1)
            {
                isActive = true;
            }
            else
            {
                isActive = false;
            }
        }
    }
    public void OpenGate()
    {
        if (isActive)
        {
            door.Open_door();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Animal animal))
        {
            if (!PassAllowed(type, animal))
            {
                //   animal.Find_First_Point();
                animal.FearingAnimal(transform);
                animal.canFear = false;
            }
            else
            {
                if (!animal.inSide)
                {
                    Out_Side_animals.Remove(animal);
                    In_Side_animals.Add(animal);
                    DisplayAnimal_count();
                }
            }
        }
    }   
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Animal animal))
        {
            if(!PassAllowed(type, animal))
            {
                animal.canFear = true;
            }
            else
            {
                animal.inSide = false;
                In_Side_animals.Remove(animal);
                Out_Side_animals.Add(animal);
                DisplayAnimal_count();
            }
        }
    }
    private bool PassAllowed(Type type, Animal animalType)
    {
        if (type == Type.Goose && animalType.animalType != Animal.AnimalType.Goose)
        {
            return false;
        }
        else if (type == Type.Goat && animalType.animalType != Animal.AnimalType.Goat)
        {
            return false;
        }
        else if (type == Type.Ostrich && animalType.animalType != Animal.AnimalType.Ostrich)
        {
            return false;
        }
        else if (type == Type.Pig && animalType.animalType != Animal.AnimalType.Pig)
        {
            return false;
        }
        else if (type == Type.Cow && animalType.animalType != Animal.AnimalType.Cow)
        {
            return false;
        }
        else if (type == Type.Horse && animalType.animalType != Animal.AnimalType.Horse)
        {
            return false;
        }
        else if (type == Type.Sheep && animalType.animalType != Animal.AnimalType.Sheep)
        {
            return false;
        }
        else if (type == Type.Chicken && animalType.animalType != Animal.AnimalType.Chicken)
        {
            return false;
        }

        return true;
    }
    public Vector3 SpawnPos()
    {
        Vector3 randomPos = Random.insideUnitSphere * spawnRaduis + transform.position;
        Vector3 pos = new Vector3(randomPos.x, 0, randomPos.z);
        return pos;
    }

    public void BuyAnimal(Animal prefab, Transform zoneToWalk, float walkRadius, Transform parrent, int Weight)
    {
        Animal go = Instantiate(prefab, SpawnPos(), Quaternion.identity, parrent);
        In_Side_animals.Add(go);
        go.SetPriority(1);
        go.Weight = Weight;
        go.zone_to_walk = zoneToWalk;
        go.radius_walk_zone = walkRadius;
        go.inSide = true;
        go.state = Animal.State.stay;

        DisplayAnimal_count();
    }
    public void SpawnAnimals(Animal prefab, int maxCount, Transform zoneToWalk, float walkRadius, Transform parrent, int Weight, int priority)
    {
   //     OpenGate();

        animal_max_count = maxCount;
        if (!firstSpawn)
        {
            for (int i = In_Side_animals.Count; i < maxCount; i++)
            {
                Animal go = Instantiate(prefab, SpawnPos(), Quaternion.identity, parrent);
                In_Side_animals.Add(go);
                go.SetPriority(i + priority);
                go.Weight = Weight;
                go.zone_to_walk = zoneToWalk;
                go.radius_walk_zone = walkRadius;
                go.inSide = true;
            }
        }
        else
        {
            for (int i = 0; i < maxCount; i++)
            {
                Animal go = Instantiate(prefab, SpawnPos(), Quaternion.identity, parrent);
                In_Side_animals.Add(go);
                go.SetPriority(i + priority);
                go.Weight = Weight;
                go.zone_to_walk = zoneToWalk;
                go.radius_walk_zone = walkRadius;
                go.inSide = true;
                go.state = Animal.State.stay;
            }
            firstSpawn = false;
        }
        DisplayAnimal_count();
        // StartCoroutine(OpenGates());
    }

    public void StartDay()
    {
        StartCoroutine(StartDay_courutine());
    }
    public void EndDay()
    {
        // StartCoroutine(EndDay_courutine());
        foreach (var item in In_Side_animals)
        {
            item.canFear = false;
            item.Patroling_In_Main_zone();
        }
    }
    public int Day_result()
    {
        diedAnimals = 0;
        if (isActive)
        {
            door.Close_door();
        }
        float rng = Random.Range(10, 50);
        float tmp = (float)Out_Side_animals.Count / 100;
        float deadAnimals = tmp * rng;

        deadAnimals = Mathf.RoundToInt(deadAnimals);
        
        for (int i = Out_Side_animals.Count; i > 0; i--)
        {
            if (deadAnimals > 0)
            {
                diedAnimals++;
                Destroy(Out_Side_animals[i - 1].gameObject);
                Out_Side_animals.RemoveAt(i - 1);
                deadAnimals--;
            }
            else
            {
                In_Side_animals.Add(Out_Side_animals[i - 1]);
                Out_Side_animals.RemoveAt(Out_Side_animals.Count - 1);
            }
        }
        foreach (var item in In_Side_animals)
        {
            item.ResetAnimal();
        }
        return diedAnimals;
    }

    private void DisplayAnimal_count()
    {
        animals_count.text = In_Side_animals.Count.ToString() + "/" + animal_max_count.ToString();
    }

    private IEnumerator StartDay_courutine()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < In_Side_animals.Count; i++)
        {
            In_Side_animals[i].canFear = false;
            In_Side_animals[i].Find_First_Point();
            yield return new WaitForSeconds(.01f);
        }
      /*  foreach (var item in In_Side_animals)
        {
            item.canFear = false;
            item.Find_First_Point();
            

        }*/
        yield return new WaitForSeconds(7f);
        foreach (var item in In_Side_animals)
        {
            item.canFear = true;
        }
    }
    private IEnumerator EndDay_courutine()
    {
        yield return new WaitForSeconds(2f);
        foreach (var item in In_Side_animals)
        {
            item.canFear = false;
            item.Patroling_In_Main_zone();
        }
 
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRaduis);
    //    Gizmos.DrawWireCube(transform.position, spawnRaduisCube);
    }
}