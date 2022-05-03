using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInYard : MonoBehaviour
{
    [SerializeField] private List<Dogs_Patroling> dogs;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player animal))
        {
            var rng = Random.Range(0, 2);
            Transform POS = animal.transform;
            dogs[rng].EnemyComing(POS);
            animal.WrongWay();
            animal.canFear = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player animal))
        {
            animal.canFear = true;
        }
    }
}
