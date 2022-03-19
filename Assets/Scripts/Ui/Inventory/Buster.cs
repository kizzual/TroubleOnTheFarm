using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Buster : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject worldPrefab;
    [SerializeField] private Inventory_container Inventory_container;
    public void OnPointerDown(PointerEventData eventData)
    {
        Inventory_container.CreateFeedPrefab(worldPrefab);

    }
    
}
 