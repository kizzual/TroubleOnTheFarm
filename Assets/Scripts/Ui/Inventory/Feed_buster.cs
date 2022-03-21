using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed_buster : MonoBehaviour
{
    [SerializeField] private float LifeTime;

    private float timer;
    private SphereCollider collider;
    public bool isActive = false;

    public List<Animal> eatingAnimals;
    [SerializeField] float sphereRadius;
    public enum FeedType
    {
        Goose_Pig_Chicken,
        Goat_Sheep,
        Ostrich,
        Cow_horse,
    }
    public FeedType feedtype;

    private void Start()
    {
        collider = GetComponent<SphereCollider>();
        collider.enabled = false;
    }
    void Update()
    {
        if (isActive)
        {
            timer += Time.deltaTime;
            if(timer > LifeTime -1 && timer < LifeTime)
            {
                collider.enabled = false;
                EatingFinished();
            }
            if (timer >= LifeTime)
            {
                Destroy(gameObject);
            }
        }
    }
    public void AciveFeedBuster()
    {
        isActive = true;
        collider.enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Animal animal))
        {
            if (!animal.inSide && checkFeedType(animal.animalType))
            {
                animal.eating = true;
                animal.UsedFeedBuster(SpawnPos(), this);
                eatingAnimals.Add(animal);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Animal animal))
        {
            if (!animal.inSide && checkFeedType(animal.animalType))
            {
                eatingAnimals.Remove(animal);
                animal.state = Animal.State.stay;
                animal.eating = false;
            }
        }
    }
    private void EatingFinished()
    {
        foreach (var item in eatingAnimals)
        {
            item.eating = false;
            item.state = Animal.State.stay;
            Debug.Log("EatEnded");
        }

    }
    public Vector3 SpawnPos()
    {
        Vector3 randomPos = Random.insideUnitSphere * sphereRadius + transform.position;
        Vector3 pos = new Vector3(randomPos.x, 0, randomPos.z);
        return pos;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sphereRadius);
    }

    private bool checkFeedType(Animal.AnimalType type)
    {
        if (feedtype == FeedType.Goose_Pig_Chicken)  
        {
            if(type == Animal.AnimalType.Goose || type == Animal.AnimalType.Pig || type == Animal.AnimalType.Chicken) return true;
        }
        else if (feedtype == FeedType.Goat_Sheep)
        {
            if(type == Animal.AnimalType.Goat || type == Animal.AnimalType.Sheep) return true;
        }
        else if (feedtype == FeedType.Ostrich && type == Animal.AnimalType.Ostrich)
        {
            return true;
        }
        else if (feedtype == FeedType.Cow_horse) 
        {
            if(type == Animal.AnimalType.Cow || type == Animal.AnimalType.Horse) return true;
        }
       
        return false;
    }
}
