using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameTutorial : MonoBehaviour
{
    [SerializeField] private GameObject TutorialPanel;
    [SerializeField] private List<GameObject> Pages;
    [SerializeField] private List<GameObject> LeftButton;
    [SerializeField] private List<GameObject> RightButton;
    [SerializeField] private Container container;

    [SerializeField] private InputDetect input;
    [SerializeField] private CameraMove cam;
    [SerializeField] private Game_controller _gameController;


    [SerializeField] private GameObject StartGame_Tutorial;
    [SerializeField] private GameObject Merge_Tutorial;
    [SerializeField] private GameObject StartFirstDay_Tutorial_panel;
    [SerializeField] private List<GameObject> StartFirstDay_Tutorial_pages;
    [SerializeField] private GameObject EndFirstDay_Tutorial;
    [SerializeField] private GameObject StartSecondtDay_Tutorial_panel_1;
    [SerializeField] private GameObject StartSecondtDay_Tutorial_panel_2;
    [SerializeField] private List<GameObject> StartSecondDay_Tutorial_pages;



    public bool firstTime;
    public int pageIndex;
    void Awake()
    {
        pageIndex = 0;
    }

    public void LeftPage()
    {
        if (StartFirstDay_Tutorial_panel.activeSelf)
        {
            foreach (var item in RightButton)
            {
                item.SetActive(true);
            }
            if (pageIndex - 1 >= 0)
            {
                StartFirstDay_Tutorial_pages[pageIndex].SetActive(false);
                pageIndex--;
                StartFirstDay_Tutorial_pages[pageIndex].SetActive(true);
            }
            if (pageIndex == 0)
            {
                foreach (var item in LeftButton)
                {
                    item.SetActive(false);
                }

            }
        }
      

    }
    public void RightPage()
    {
        if (StartFirstDay_Tutorial_panel.activeSelf)
        {
     
            foreach (var item in LeftButton)
            {
                item.SetActive(true);
            }

            if (pageIndex  <= StartFirstDay_Tutorial_pages.Count)
            {
                StartFirstDay_Tutorial_pages[pageIndex].SetActive(false);
                pageIndex++;
                StartFirstDay_Tutorial_pages[pageIndex].SetActive(true);
            }
            if (pageIndex == StartFirstDay_Tutorial_pages.Count -1 )
            {
                foreach (var item in RightButton)
                {
                    item.SetActive(false);
                }

            }
        }
      

    }
    public void Exit(GameObject obj)
    {
        cam.IsStoped = false;
        input.TutorialIsActive = false;
        if (StartSecondtDay_Tutorial_panel_1.activeSelf || StartFirstDay_Tutorial_panel.activeSelf)
        {
            Debug.Log("s");
             _gameController.DayIsActive = true;
        }
        obj.SetActive(false);
            
    }
    public void OkButtonFirstDay()
    {
        foreach (var item in LeftButton)
        {
            item.SetActive(true);
        }
     
        if (pageIndex == StartFirstDay_Tutorial_pages.Count-1)
        {

            cam.IsStoped = false;
            input.TutorialIsActive = false;
            _gameController.DayIsActive = true;
            StartFirstDay_Tutorial_panel.SetActive(false);


        }
        if (pageIndex + 1 <= StartFirstDay_Tutorial_pages.Count - 1)
        {
            StartFirstDay_Tutorial_pages[pageIndex].SetActive(false);
            pageIndex++;
            StartFirstDay_Tutorial_pages[pageIndex].SetActive(true);
        }
        if (pageIndex == StartFirstDay_Tutorial_pages.Count-1)
        {
            foreach (var item in RightButton)
            {
                item.SetActive(false);
            }
        }
    }
   

    public void OkButton(GameObject obj)
    {
        cam.IsStoped = false;
        input.TutorialIsActive = false;
        if(EndFirstDay_Tutorial.activeSelf)
        {
            container.Finish_ui.gameObject.SetActive(true);
        }
        else if(Merge_Tutorial.activeSelf)
        {
            container.merge_ui.gameObject.SetActive(true);
        }

        if (StartSecondtDay_Tutorial_panel_1.activeSelf)
        {
            Bust_tutorial._instance.StartBustAnimation();
        }
        
        obj.SetActive(false);
    }
    public void StartGameTutor(bool activate)
    {
        if (activate)
        {
            StartGame_Tutorial.SetActive(true);
        }
        else
        {
            StartGame_Tutorial.SetActive(false);
        }
    }
    public void StartFirstDayTutor(bool activate)
    {
        pageIndex = 0;

        if (activate)
        {
            foreach (var item in LeftButton)
            {
                item.SetActive(false);
            }
            foreach (var item in RightButton)
            {
                item.SetActive(true);
            }
            StartFirstDay_Tutorial_panel.SetActive(true);
            StartFirstDay_Tutorial_pages[0].SetActive(true);
            StartFirstDay_Tutorial_pages[1].SetActive(false);
            cam.IsStoped = true;
            input.TutorialIsActive = true;
        }
        else
        {
            StartFirstDay_Tutorial_panel.SetActive(false);
            cam.IsStoped = false;
            input.TutorialIsActive = false;
        }
    }
    public void EndFirstDayTutor(bool acivate)
    {
        if(acivate)
        {
            EndFirstDay_Tutorial.SetActive(true);
        }
        else
        {
            EndFirstDay_Tutorial.SetActive(false);
        }
    }
    public void StartMergeTutor(bool acivate)
    {
        if (acivate)
        {
            Merge_Tutorial.SetActive(true);
        }
        else
        {
            Merge_Tutorial.SetActive(false);
        }
    }
    public void StartSecondDayTutor_1(bool activate)
    {

        if (activate)
        {
            StartSecondtDay_Tutorial_panel_1.SetActive(true);
            StartSecondDay_Tutorial_pages[0].SetActive(true);
            cam.IsStoped = true;
            input.TutorialIsActive = true;
        }
        else
        {
            StartSecondtDay_Tutorial_panel_1.SetActive(false);
            cam.IsStoped = false;
            input.TutorialIsActive = false;
        }
    }
    public void StartSecondDayTutor_2(bool activate)
    {

        if (activate)
        {

            StartSecondtDay_Tutorial_panel_2.SetActive(true);
            cam.IsStoped = true;
            input.TutorialIsActive = true;
        }
        else
        {
            StartSecondtDay_Tutorial_panel_2.SetActive(false);
            cam.IsStoped = false;
            input.TutorialIsActive = false;
        }
    }

}
