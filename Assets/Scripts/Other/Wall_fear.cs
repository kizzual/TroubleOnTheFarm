using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_fear : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Animal animal))
        {
            animal.FearingAnimal(transform);
            animal.canFear = false;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Animal animal))
        {
         
            animal.canFear = true;

        }
    }
}
