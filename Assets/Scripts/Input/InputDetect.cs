using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputDetect : MonoBehaviour
{
    public float sphere_radius;
    public Camera camera;
    public LayerMask layer;
    public GameObject target;

    public static GameObject currentFeedPrefab;

    public bool InGame = false;
    public static bool FeedBusterIsActive = false;
    private bool feedIsHiding = true;
    [SerializeField] private Inventory_container inventory;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (InGame)
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
            else if (!InGame)
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.TryGetComponent(out ShopInGame shop))
                    {
                        shop.BuyAnimal();
                    }
                }
            }
        }


        else if (Input.GetMouseButton(0) && FeedBusterIsActive)
        {
            if (!IsMouseOverUiWithIgnores())
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    inventory.MovePrefab(new Vector3(hit.point.x, 0, hit.point.z));
                    if (feedIsHiding)
                    {
                        inventory.DisplayPrefab(true);
                        feedIsHiding = false;
                    }
                }
            }
            else if (IsMouseOverUiWithIgnores())
            {
                if (!feedIsHiding)
                {
                    inventory.DisplayPrefab(false);
                    feedIsHiding = true;
                }
            }
        }
        else if (Input.GetMouseButtonUp(0) && FeedBusterIsActive)
        {
            FeedBusterIsActive = false;

            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                inventory.MovePrefab_test(new Vector3(hit.point.x, 0, hit.point.z));
            }

            if (!IsMouseOverUiWithIgnores())
            {
                inventory.AddingFeedBusterToList();

            }
            else if (IsMouseOverUiWithIgnores())
            {
                inventory.DestroyPrefab();
            }

        }
    }
    private bool IsMouseOverUiWithIgnores()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResultList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultList);
        for (int i = 0; i < raycastResultList.Count; i++)
        { 
            if(raycastResultList[i].gameObject.GetComponent<IgnoreRaycastUI>() != null)
            {
                raycastResultList.RemoveAt(i);
                i--;
            }
        }
        return raycastResultList.Count > 0;
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
