using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
public class AnimalPaddock : MonoBehaviour
{
    public bool isActive;
    [SerializeField] private Door door;
    [SerializeField] private float spawnRaduis;
//  [SerializeField] private Vector3 spawnRaduisCube;

    [SerializeField] TextMeshPro animals_count;
    private int animal_max_count;
    bool dayIsActive = false;
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

    [SerializeField]
    private List<RandomPoint> randomZoneInSide;
    public List<Player> In_Side_animals;
    public List<Player> Out_Side_animals;
    public List<NavMeshAgent> agents;
    private bool firstSpawn = true;
    [SerializeField] private Transform door_zone_to_walk;
    public bool IsClosed = true;
    private int diedAnimals;
    public Game_controller _gameController;
    void Awake()
    {
        CheckSave();
   //     door.Close_door();
    }
    private void Start()
    {
        if(!isActive)
        {
            IsClosed = true;
            door.gameObject.layer = 3;
        }
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
            IsClosed = false;
            door.Open_door();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player animal))
        {
            if (!PassAllowed(type, animal))
            {
                animal.EnterinToWrongPaddock = true;
                animal.WrongWay();
                animal.canFear = false;
            //    animal.RunFromWrongPaddock();
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
        if (other.TryGetComponent(out Player animal))
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
    private bool PassAllowed(Type type, Player animalType)
    {
        if (type == Type.Goose && animalType.animalType != Player.AnimalType.Goose)
        {
            return false;
        }
        else if (type == Type.Goat && animalType.animalType != Player.AnimalType.Goat)
        {
            return false;
        }
        else if (type == Type.Ostrich && animalType.animalType != Player.AnimalType.Ostrich)
        {
            return false;
        }
        else if (type == Type.Pig && animalType.animalType != Player.AnimalType.Pig)
        {
            return false;
        }
        else if (type == Type.Cow && animalType.animalType != Player.AnimalType.Cow)
        {
            return false;
        }
        else if (type == Type.Horse && animalType.animalType != Player.AnimalType.Horse)
        {
            return false;
        }
        else if (type == Type.Sheep && animalType.animalType != Player.AnimalType.Sheep)
        {
            return false;
        }
        else if (type == Type.Chicken && animalType.animalType != Player.AnimalType.Chicken)
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

    public void BuyAnimal(Player prefab, int maxCount,Transform zoneToWalk, float walkRadius, Transform parrent, int Weight, List<RandomPoint> randomPoints)
    {
        animal_max_count = maxCount;

        Player go = Instantiate(prefab, SpawnPos(), Quaternion.identity, parrent);
        In_Side_animals.Add(go);
        go.inSide = true;
        go.pointToGoOutSide = randomPoints;
        go.pointToGoInSide = randomZoneInSide;


        DisplayAnimal_count();
    }
    public void SpawnAnimals(Player prefab, int maxCount, Transform zoneToWalk, float walkRadius, Transform parrent, int Weight, int priority,List<RandomPoint> randomPoints)
    {

        animal_max_count = maxCount;
        if (!firstSpawn)
        {
            for (int i = In_Side_animals.Count; i < maxCount; i++)
            {
                Player go = Instantiate(prefab, SpawnPos(), Quaternion.identity, parrent);
                In_Side_animals.Add(go);
                In_Side_animals[i].pointToGoInSide = randomZoneInSide;
                In_Side_animals[i].pointToGoOutSide = randomPoints;
                go.inSide = true;
            }
        }
        else
        {
            for (int i = 0; i < maxCount; i++)
            {
                Player go = Instantiate(prefab, SpawnPos(), Quaternion.identity, parrent);
                In_Side_animals.Add(go);
                In_Side_animals[i].pointToGoInSide = randomZoneInSide;
                In_Side_animals[i].pointToGoOutSide = randomPoints;
                go.inSide = true;
            }
            firstSpawn = false;
        }
        DisplayAnimal_count();
    }

    public void MoveAnimalsToWalkingZone(List<RandomPoint> randomPoints)
    {
        foreach (var item in In_Side_animals)
        {
            item.StartDayRun();

        }
    }
    public void StartDay()
    {
        if (isActive)
        {
            dayIsActive = true;

        }
        for (int i = 0; i < In_Side_animals.Count; i++)
        {
            In_Side_animals[i].canFear = true;
        }
        for (int i = 0; i < Out_Side_animals.Count; i++)
        {
            Out_Side_animals[i].canFear = true;

        }

    }
    public void EndDay()
    {
        foreach (var item in In_Side_animals)
        {
            item.canFear = false;
            item.StartPatroling();
        }
        door.gameObject.layer = 3;
    }
    public int Day_result()
    {
        diedAnimals = 0;
        if (isActive)
        {
            door.Close_door();
        }
        float rng = Random.Range(30, 60);
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
        animal_max_count = In_Side_animals.Count;
        animals_count.text = In_Side_animals.Count.ToString() + "/" + animal_max_count.ToString();

        return diedAnimals;
    }
    private void DisplayAnimal_count()
    {
        animals_count.text = In_Side_animals.Count.ToString() + "/" + animal_max_count.ToString();
        if(dayIsActive && In_Side_animals.Count == animal_max_count && _gameController.DayIsActive)
        {
            
            StartCoroutine(close());
        }
    }
    IEnumerator close()
    {
        yield return new WaitForSeconds(1f);
        if (dayIsActive && In_Side_animals.Count == animal_max_count)
        {
           
            IsClosed = true;
            door.Close_door();
            SwtichGatesLayer(false);
            _gameController.CheckClosedPaddocks();

        }
    }
    public void SwtichGatesLayer(bool canTouch)
    {

        if (canTouch && isActive)
        {
            door.gameObject.layer = 8;
        }
        else if(!canTouch)
        {
            door.gameObject.layer = 3;
            
        }
    }
    public void EnableColision(bool on)
    {
        door.EnableColision(on);
        if(!on)
        {
            foreach (var item in In_Side_animals)
            {
                item.FindNewZone();
            }
        }
    }
    public void SoundStatus(bool isOn)
    {
        if (isOn)
        {
            foreach (var item in In_Side_animals)
            {
                item.soundIsOn = true;
            }
            foreach (var item in Out_Side_animals)
            {
                item.soundIsOn = true;
            }
        }
        else
        {
            foreach (var item in In_Side_animals)
            {
                item.soundIsOn = false;
            }
            foreach (var item in Out_Side_animals)
            {
                item.soundIsOn = false;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRaduis);
    }
}