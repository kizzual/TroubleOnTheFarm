using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPoint : MonoBehaviour
{
    [SerializeField] private float SphereRadius;
     void Start()
    {
    }
    public Vector3 GetRandomPoint()
    {
        Vector3 randomPos = Random.insideUnitSphere * SphereRadius + transform.position;
        Vector3 pos = new Vector3(randomPos.x, 0, randomPos.z);
        return pos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, SphereRadius);
    }
}
