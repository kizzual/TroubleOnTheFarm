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
        if (other.TryGetComponent(out Player animal))
        {
            if (!animal.dayIsActive)
            {
                if(!animal.inSide)
                {
                    animal.WrongWay();
                    animal.canFear = false;

                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player animal))
        {
            if(!animal.inSide)
            {
                animal.canFear = true;

            }

        }
    }
}
