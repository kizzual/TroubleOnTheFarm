using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPaddock : MonoBehaviour
{
    public bool isActive;
    [SerializeField] private GameObject door;
    [SerializeField] private float spawnRaduis;
    public enum Type
    {
        pig,
        horse
    }
    public Type type;

    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Animal animal))
        {
            if (!PassAllowed(type, animal))
            {
                animal.canFear = false;
                animal.Find_First_Point();
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
        }
    }

    /// <summary>
    /// ƒописать всех животных перед тестами
    /// </summary>
    private bool PassAllowed(Type type, Animal animalType)
    {
        if (type == Type.pig && animalType.animalType != Animal.AnimalType.Pig)
        {
            return false;
        }
        return true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRaduis);
    }
    public Vector3 SpawnPos()
    {
        Vector3 randomPos = Random.insideUnitSphere * spawnRaduis + transform.position;
        Vector3 pos = new Vector3(randomPos.x, 0, randomPos.z);
        return pos;
    }
}
