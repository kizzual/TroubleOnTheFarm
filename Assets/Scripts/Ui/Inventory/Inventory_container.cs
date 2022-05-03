using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_container : MonoBehaviour
{
    private  GameObject currentFeedPrefab;
    [SerializeField] private  Game_controller Game_controller;

    [SerializeField] private Animator feedAnimation;
    [SerializeField] private List<Image> feed_busters;
    [SerializeField] private Image time_buster;
    [SerializeField] private Text feed_buster_count_text;
    [SerializeField] private Text time_buster_count_text;
    [SerializeField] private List<Mask> FeedMasks;
    public  int feed_buster_count;
    public  int time_buster_count;

    private bool feedBusterIsHide = true;

    void Start()
    {

    }


    void Update()
    {
        
        
    }
    public bool CheckBustersCount()
    {
        if (feed_buster_count > 0) return true;
        else return false;

    }
    public  void CreateFeedPrefab(GameObject prefab)
    {
        var go = Instantiate(prefab);
        currentFeedPrefab = go;
        InputDetect.FeedBusterIsActive = true;
        CameraMove.CanMoveCamera = false;
    }

    public  void DestroyPrefab()
    {
        Destroy(currentFeedPrefab);
    }

    public void AddingFeedBusterToList()
    { 
        currentFeedPrefab.GetComponent<Feed_buster>().AciveFeedBuster();
        feed_buster_count--;
        Display_Busters_Count(feed_buster_count, time_buster_count);
        CameraMove.CanMoveCamera = true;

    }
    private void Check_Feed_busters_count(int count)
    {
        if(count < 1)
        {
            foreach (var item in feed_busters)
            {
                item.raycastTarget = false;
            }
        }
        else if (count > 0)
        {
            foreach (var item in feed_busters)
            {
                item.raycastTarget = true;
            }
        }
    }
    private void Check_time_busters_count(int count)
    {
        if (count < 1)
        {
            time_buster.raycastTarget = false;
        }
        else if (count > 0)
        {
            time_buster.raycastTarget = true;
        }
    }
    public void Display_Busters_Count(int feed_count, int time_count)
    {
        feed_buster_count = feed_count;
        time_buster_count = time_count;
        Check_Feed_busters_count(feed_count);
        Check_time_busters_count(time_count);
        feed_buster_count_text.text = feed_count.ToString();
        time_buster_count_text.text = time_count.ToString();
    }
    public  void DisplayPrefab(bool enabled)
    {
        if (enabled)
        {
            currentFeedPrefab.SetActive(true);
        }
        else
        {
            currentFeedPrefab.SetActive(false);
        }
    }
    public  void MovePrefab(Vector3 position)
    {
        currentFeedPrefab.transform.position = position;
    }
    public  void MovePrefab_test(Vector3 position)
    {
        currentFeedPrefab.transform.position = position;
    }

    public void TimeBustUsing()
    {
        if (time_buster_count > 0)
        {
            time_buster_count--;
            Display_Busters_Count(feed_buster_count, time_buster_count);
            Game_controller.Day_length += 30;
        }
    }
    public void DisplayBustPanel()
    {
        if(feedBusterIsHide)
        {
            feedAnimation.SetBool("ShowBuster", true);
            feedBusterIsHide = false;
            foreach (var item in FeedMasks)
            {
                item.raycastTarget = true;
            }
        }
        else
        {
            feedAnimation.SetBool("ShowBuster", false);
            feedBusterIsHide = true;
            foreach (var item in FeedMasks)
            {
                item.raycastTarget = false;
            }
        }
    }
}
