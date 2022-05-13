using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_UI : MonoBehaviour
{
    [SerializeField] private Text gold_earned_text;
    [SerializeField] private Text feedCount_text;
    [SerializeField] private Text time_text;
    [SerializeField] private GameObject Shop;

    [SerializeField] private Text FeedBust_price;
    [SerializeField] private Text TimeBust_price;
    public Button startDayButton;

    [SerializeField] private List<Animator> ShowUI;

    void Start()
    {
        StartCoroutine(ShowUIStart());
    }
    IEnumerator ShowUIStart()
    {
        foreach (var item in ShowUI)
        {
            item.SetBool("HideUI", true);
        }
        yield return new WaitForSeconds(2.3f);
        foreach (var item in ShowUI)
        {
            item.SetBool("HideUI", false);
            item.SetBool("ShowUI", true);
        }
    }

    public void DisplayBusters_price(int FeedPirce, int TimePrice)
    {
        FeedBust_price.text = FeedPirce.ToString();
        TimeBust_price.text = TimePrice.ToString();
    }

    public void Display_Bust_counts (int feedCount, int timeCount)
    {

        feedCount_text.text = feedCount.ToString();
        time_text.text = timeCount.ToString();

    }

    public void GoToShop()
    {
        if (Shop.activeSelf)
        {
            Shop.SetActive(false);
        }
        else
        {
            Shop.SetActive(true);
        }
    }






    
  
}
