using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayShopImage : MonoBehaviour
{
    [SerializeField] private GameObject BuyPaddock_panel;
    [SerializeField] private GameObject BuyAnimal_panel;
    [SerializeField] private GameObject MaxAnimalCount_panel;

    private void Start()
    {
 
    }
    public void Buy_Paddock()
    {
        BuyPaddock_panel.SetActive(true);
        BuyAnimal_panel.SetActive(false);
        MaxAnimalCount_panel.SetActive(false);
    }
    public void BuyAnimal()
    {

        BuyPaddock_panel.SetActive(false);
        BuyAnimal_panel.SetActive(true);
        MaxAnimalCount_panel.SetActive(false);

    }
    public void MaxAnimal()
    {
        BuyPaddock_panel.SetActive(false);
        BuyAnimal_panel.SetActive(false);
        MaxAnimalCount_panel.SetActive(true);

    }
}
