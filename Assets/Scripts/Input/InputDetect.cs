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
    public SoundController _soundController;
    public static GameObject currentFeedPrefab;
    public Game_controller _gameController;
    public  bool InGame = false;
    public static bool FeedBusterIsActive = false;
    private bool feedIsHiding = true;
    [SerializeField] private Inventory_container inventory;
    public LayerMask layerToRay;
    [SerializeField] private Animator shadowSprite;
    public bool isMobileInput;
    public bool IsMoving = false;
    Vector3 startClickPosition;
    public bool TutorialIsActive = false;
    void Update()
    {
        if (!TutorialIsActive)
        {
            if (!isMobileInput)
            {

                if (Input.GetMouseButtonDown(0))
                {


                    if (InGame)
                    {
                        if (!IsMouseOverUiWithIgnores())
                        {
                            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                            RaycastHit hit;
                            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerToRay))
                            {

                                if (!hit.collider.CompareTag("Gate"))
                                {
                                    transform.position = new Vector3(hit.point.x, 0, hit.point.z);

                                    shadowSprite.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);

                                    shadowSprite.gameObject.SetActive(false);
                                    shadowSprite.gameObject.SetActive(true);

                                    DisplayShadowClick();
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

                    /*      else if (Input.GetMouseButton(0) && FeedBusterIsActive)
                          {
                              if (!IsMouseOverUiWithIgnores())
                              {
                                  Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                                  RaycastHit hit;
                                  if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerToRay))
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
                              if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerToRay))
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

                          }*/

                }

                else if (Input.GetMouseButton(0) && FeedBusterIsActive)
                {
                    Debug.Log("ACTIVE");

                    if (!IsMouseOverUiWithIgnores())
                    {
                        Debug.Log("ASD");
                        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerToRay))
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
                    Debug.Log("UP");

                    Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerToRay))
                    {
                        inventory.MovePrefab_test(new Vector3(hit.point.x, 0, hit.point.z));
                    }

                    if (!IsMouseOverUiWithIgnores())
                    {
                        inventory.AddingFeedBusterToList();
                        if(_gameController.Day == 1)
                        {
                            Bust_tutorial._instance.NextStepBustTutor();
                        }
                    }
                    else if (IsMouseOverUiWithIgnores())
                    {
                        inventory.DestroyPrefab();
                    }

                }
            }
            else if (isMobileInput)
            {
                if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    startClickPosition = Input.GetTouch(0).position;
                }
                if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved && Vector3.Distance(startClickPosition, Input.GetTouch(0).position) > 10)
                {
                    IsMoving = true;
                }

                if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended && !IsMoving)
                {
                    if (InGame)
                    {
                        if (!IsMouseOverUiWithIgnores())
                        {

                            Ray ray = camera.ScreenPointToRay(Input.GetTouch(0).position);
                            RaycastHit hit;
                            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerToRay))
                            {

                                if (!hit.collider.CompareTag("Gate"))
                                {
                                    transform.position = new Vector3(hit.point.x, 0, hit.point.z);

                                    shadowSprite.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);

                                    shadowSprite.gameObject.SetActive(false);
                                    shadowSprite.gameObject.SetActive(true);

                                    DisplayShadowClick();
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
                    else if (!InGame)
                    {
                        Ray ray = camera.ScreenPointToRay(Input.GetTouch(0).position);
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


                else if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved && FeedBusterIsActive)
                {
                    CameraMove.CanMoveCamera = false;
                    if (!IsMouseOverUiWithIgnores())
                    {
                        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerToRay))
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
                else if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended && FeedBusterIsActive)
                {
                    FeedBusterIsActive = false;
                    CameraMove.CanMoveCamera = true;

                    Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerToRay))
                    {
                        inventory.MovePrefab_test(new Vector3(hit.point.x, 0, hit.point.z));
                    }

                    if (!IsMouseOverUiWithIgnores())
                    {
                        inventory.AddingFeedBusterToList();
                        if (_gameController.Day == 1)
                        {
                            Bust_tutorial._instance.NextStepBustTutor();
                        }
                    }
                    else if (IsMouseOverUiWithIgnores())
                    {
                        inventory.DestroyPrefab();
                    }
                }
            }
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                IsMoving = false;
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
        _soundController.Fearing();
           Collider[] hitColliders = Physics.OverlapSphere(position, sphere_radius , layer);
        foreach (var hitCollider in hitColliders)
        {

            if (hitCollider.TryGetComponent(out Player animal))
            {
                //   animal.FearingAnimal(transform);
                animal.FearAnimal(transform);
                animal.PlaySound();
            }
        }
    }


    private void DisplayShadowClick()
    {
        shadowSprite.SetTrigger("Shadow");

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, sphere_radius);
    }

}
