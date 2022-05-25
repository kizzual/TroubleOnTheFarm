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
    [SerializeField] private Game_controller _gameController;
    [SerializeField] private Text FeedBust_price;
    [SerializeField] private Text TimeBust_price;
    public Button startDayButton;
    public Container container;
    [SerializeField] private List<Animator> ShowUI;
    private int goldClickCount;
    public GameObject ADS_Panel;
    private int RewardGoldCount;
    void Start()
    {
        StartCoroutine(ShowUIStart());
        RewardGoldCount = PlayerPrefs.GetInt("REWARD");

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
            if (_gameController.Day == 1)
            {
                container.busters_toturial.SwitchTutorial();
            }
        }
        else
        {
            Shop.SetActive(true);
            if (_gameController.Day == 1 )
            {
                container.busters_toturial.SwitchTutorial();
            }
        }
    }

    public void Test()
    {
        if (_gameController.Day == 1 && goldClickCount < 2)
        {
            goldClickCount++;
            _gameController.GoldForSellRessources(50, false);
            container.busters_toturial.SwitchTutorial();
            container._soundController.BuySometing();
            return;
        }
        else if(_gameController.Day != 1 && _gameController.Day != 0)
        {
            if (PlayerPrefs.HasKey("REWARD"))
            {
                RewardGoldCount = PlayerPrefs.GetInt("REWARD");
            }
            if (RewardGoldCount < 2)
            {
                StartCoroutine(ShowADS());
                RewardGoldCount++;
            }

        }
    }
    private IEnumerator ShowADS()
    {
        ADS_Panel.SetActive(true);

        yield return new WaitForSeconds(2f);

        ADS_Panel.SetActive(false);
        _gameController.GoldForSellRessources(50);
        container._soundController.BuySometing();
        PlayerPrefs.SetInt("REWARD", RewardGoldCount);
    }




    
  
}
