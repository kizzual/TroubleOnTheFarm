using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetect : MonoBehaviour
{
    public float sphere_radius;
    public LayerMask layer; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (!hit.collider.CompareTag("Finish"))
                {
                    transform.position = new Vector3(hit.point.x, 0, hit.point.z);
                    CheckAnimals(transform.position);
                }
            }
        }
    }
    private void CheckAnimals(Vector3 position)
    {
        Collider[] hitColliders = Physics.OverlapSphere(position, sphere_radius , layer);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent(out Animal animal))
            {
                animal.RotateAnimal(transform);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, sphere_radius);
    }
}
