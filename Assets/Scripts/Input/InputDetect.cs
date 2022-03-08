using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetect : MonoBehaviour
{
    public float sphere_radius;
    public Camera camera;
    public LayerMask layer;
    public GameObject target;
    public GameObject testPref;
    bool Spawn = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (!hit.collider.CompareTag("Gate"))
                {
                    transform.position = new Vector3(hit.point.x, 0, hit.point.z);
                    CheckAnimals(transform.position);
                }
                else if (hit.collider.CompareTag("Gate"))
                {
                    if (hit.collider.TryGetComponent(out Door door))
                    {
                        door.CloseOpenDoore();
                    }
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
                animal.FearingAnimal(transform);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, sphere_radius);
    }

}
