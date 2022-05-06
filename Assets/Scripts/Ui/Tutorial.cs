using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject TutorialPanel;
    [SerializeField] private List<GameObject> Pages;
    [SerializeField] private GameObject LeftButton;
    [SerializeField] private GameObject RightButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private InputDetect input;
    [SerializeField] private CameraMove cam;

    public bool firstTime;
    public int pageIndex;
    void Awake()
    {
        if(PlayerPrefs.HasKey("TutorialEnded"))
        {
            
            firstTime = false;
        }
        else
        {
            firstTime = true;
        }
        pageIndex = 0;
    }

    public void LeftPage()
    {
        RightButton.SetActive(true);
        if (pageIndex - 1 >= 0)
        {
            Pages[pageIndex].SetActive(false);
            pageIndex--;
            Pages[pageIndex].SetActive(true);
        }
        if (pageIndex == 0)
        {
            LeftButton.SetActive(false);
        }
    }
    public void RightPage()
    {
        LeftButton.SetActive(true);

        if (pageIndex + 1 <= Pages.Count-1)
        {
            Pages[pageIndex].SetActive(false);
            pageIndex++;
            Pages[pageIndex].SetActive(true);
        }
        if (pageIndex == Pages.Count-1)
        {
            RightButton.SetActive(false);
            PlayerPrefs.SetInt("TutorialEnded", 1);

        }

    }
    public void Exit()
    {
        TutorialPanel.SetActive(false);
        cam.IsStoped = false;
        input.TutorialIsActive = false;
        PlayerPrefs.SetInt("TutorialEnded", 1);

        if (!firstTime)
        {

            pausePanel.SetActive(true);
        }
    }
    public void OkButton()
    {
        LeftButton.SetActive(true);
        if (pageIndex + 1 == Pages.Count)
        {
            TutorialPanel.SetActive(false);
            cam.IsStoped = false;
            input.TutorialIsActive = false;

            PlayerPrefs.SetInt("TutorialEnded", 1);
            if (!firstTime)
            {
                pausePanel.SetActive(true);
                cam.IsStoped = false;
                input.TutorialIsActive = false;
            }
        }
        if (pageIndex + 1 <= Pages.Count - 1)
        {
            Pages[pageIndex].SetActive(false);
            pageIndex++;
            Pages[pageIndex].SetActive(true);
        }
        if (pageIndex + 1  == Pages.Count )
        {
            RightButton.SetActive(false);
        }
    }
    public void OpenTutorial()
    {
        LeftButton.SetActive(true);
        RightButton.SetActive(true);
        cam.IsStoped = true;
        input.TutorialIsActive = true;
          pageIndex = 0;
        foreach (var item in Pages)
        {
            item.SetActive(false);
        }
        Pages[pageIndex].SetActive(true);
        LeftButton.SetActive(false);
        TutorialPanel.SetActive(true);
        if(!firstTime)
        {
            pausePanel.SetActive(false);
        }
    }
}
