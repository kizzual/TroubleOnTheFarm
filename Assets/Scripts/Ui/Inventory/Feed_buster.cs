using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed_buster : MonoBehaviour
{
    [SerializeField] private float LifeTime;

    private float timer;
    private SphereCollider collider;
    private bool isActive = false;

    [SerializeField] float sphereRadius;
    public enum FeedType
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
                float time = Random.RandomRange(5, 15);
                animal.UsedFeedBuster(time, SpawnPos());
                animal.canFear = false;
            }
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
        if (feedtype == FeedType.Goose && type == Animal.AnimalType.Goose)
        {
            return true;
        }
        else if (feedtype == FeedType.Goat && type == Animal.AnimalType.Goat)
        {
            return true;
        }
        else if (feedtype == FeedType.Ostrich && type == Animal.AnimalType.Ostrich)
        {
            return true;
        }
        else if (feedtype == FeedType.Pig && type == Animal.AnimalType.Pig)
        {
            return true;
        }
        else if (feedtype == FeedType.Cow && type == Animal.AnimalType.Cow)
        {
            return true;
        }
        else if (feedtype == FeedType.Horse && type == Animal.AnimalType.Horse)
        {
            return true;
        }
        else if (feedtype == FeedType.Sheep && type == Animal.AnimalType.Sheep)
        {
            return true;
        }
        else if (feedtype == FeedType.Chicken && type == Animal.AnimalType.Chicken)
        {
            return true;
        }

        return false;
    }
}
