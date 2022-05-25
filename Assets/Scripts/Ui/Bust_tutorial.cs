using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bust_tutorial : MonoBehaviour
{
    public static Bust_tutorial _instance;
    public List<Image> busters;
    public List<GameObject> tutorials;
    public Game_controller _gameController;
    public Container container;
    public Button startButton;
    public Button OkButton;
    public List<GameObject> Bust_tutor;

    [SerializeField] private InputDetect input;
    [SerializeField] private CameraMove cam;
    void Start()
    {
        _instance = this;
      

    }

    void Update()
    {

    }
    public void StarTutorBUST()
    {
        if (_gameController.Day == 1)
        {
           tutorials[0].SetActive(true);
            OkButton.enabled = false;
            startButton.enabled = false;
        }
    }
    public void SwitchTutorial()
    {
        
       
        if(tutorials[0].activeSelf)
        {
            tutorials[0].SetActive(false);
            tutorials[1].SetActive(true);
            return;
        }
        if (tutorials[1].activeSelf)
        {
            tutorials[1].SetActive(false);
            tutorials[2].SetActive(true);
            return;
        }
        if (tutorials[2].activeSelf)
        {
            tutorials[2].SetActive(false);
            tutorials[3].SetActive(true);
            return;
        }
        if (tutorials[3].activeSelf)
        {
            tutorials[3].SetActive(false);
            tutorials[4].SetActive(true);
            return;
        }
        if (tutorials[4].activeSelf)
        {
            tutorials[4].SetActive(false);
            tutorials[5].SetActive(true);
            OkButton.enabled = true;
            return;
        }
        if (tutorials[5].activeSelf)
        {
            tutorials[5].SetActive(false);
            tutorials[6].SetActive(true);
            startButton.enabled = true;
            _gameController.SaveAll();

            return;
        }
        if (tutorials[6].activeSelf)
        {
            tutorials[6].SetActive(false);
            return;
        }
    }
    public void StartBustAnimation()
    {
        Bust_tutor[0].SetActive(true);
        cam.IsStoped = true;
        input.busteTutorIsActive = true;

    }
    public void NextStepBustTutor()
    {
        if (Bust_tutor[0].activeSelf)
        {
            Bust_tutor[0].SetActive(false);
            Bust_tutor[1].SetActive(true);
            foreach (var item in busters)
            {
                item.raycastTarget = false;
            }
            return;
        }
        if(Bust_tutor[1].activeSelf)
        {
            Bust_tutor[1].SetActive(false);
            _gameController.DayIsActive = true;
            cam.IsStoped = false;
            input.busteTutorIsActive = false;

            StartCoroutine(check());
            Debug.Log("1");
            return;
        }
        if (Bust_tutor[2].activeSelf)
        {
            Debug.Log("3");
            Bust_tutor[2].SetActive(false);
        }
    }

    IEnumerator check()
    {
        yield return new WaitForSeconds(5f);
        container.inGameTutorial.StartSecondDayTutor_2(true);
        Bust_tutor[2].SetActive(true);
        foreach (var item in busters)
        {
            item.raycastTarget = true;
        }
        Debug.Log("2");
    }
}
