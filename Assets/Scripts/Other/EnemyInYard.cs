using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInYard : MonoBehaviour
{
    [SerializeField] private List<Dogs_Patroling> dogs;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Animal animal))
        {
            var rng = Random.Range(0, 2);
            Transform POS = animal.transform;
            dogs[rng].EnemyComing(POS);
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
