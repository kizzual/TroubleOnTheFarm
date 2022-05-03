using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed_buster : MonoBehaviour
{
    [SerializeField] private float LifeTime;

    private float timer;
    private SphereCollider collider;
    public bool isActive = false;

    public List<Player> eatingAnimals;
    [SerializeField] float sphereRadius;
    public enum FeedType
    {
        Goose,
        Pig,
        Chicken,
        Goat,
        Sheep,
        Ostrich,
        Cow,
        horse,
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
        if (other.TryGetComponent(out Player animal))
        {
            if (!animal.inSide && checkFeedType(animal.animalType))
            {
                eatingAnimals.Add(animal);
                animal.StartEating(SpawnPos());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player animal))
        {
            if (!animal.inSide && checkFeedType(animal.animalType))
            {
                eatingAnimals.Remove(animal);
                animal.FinishEating();
            }

        }
    }
    private void EatingFinished()
    {
        foreach (var item in eatingAnimals)
        {
            item.IsEating = false;
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

    private bool checkFeedType(Player.AnimalType type)
    {
        if (feedtype == FeedType.Goose && type == Player.AnimalType.Goose) return true;
        else if (feedtype == FeedType.Pig && type == Player.AnimalType.Pig) return true;
        else if (feedtype == FeedType.Chicken && type == Player.AnimalType.Chicken) return true;
        else if (feedtype == FeedType.Goat && type == Player.AnimalType.Goat) return true;   
        else if (feedtype == FeedType.Sheep && type == Player.AnimalType.Sheep) return true;
        else if (feedtype == FeedType.Ostrich && type == Player.AnimalType.Ostrich) return true;
        else if (feedtype == FeedType.Cow && type == Player.AnimalType.Cow) return true; 
        else if (feedtype == FeedType.horse && type == Player.AnimalType.Horse) return true;
        return false;
    }
}
