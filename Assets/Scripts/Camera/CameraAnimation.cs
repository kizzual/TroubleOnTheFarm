using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    [SerializeField] Container container;
 //   [SerializeField] Transform cameraSatartPos;
    [SerializeField] private new Animator animation;
    [SerializeField] private List<Animator> UiAnimation;
    [SerializeField] private Game_controller game_controller;
    [SerializeField] private InGameTutorial tutorial;
    void Start()
    {
        animation.enabled = true;
        animation.SetTrigger("StartGame");
        StartCoroutine(ShowStartUI());
    }
 
    public void AnimationEded()
    {
        container.Goose_paddock.EnableColision(true);
        container.Goat_paddock.EnableColision(true);
        container.Ostrich_paddock.EnableColision(true);
        container.Pig_paddock.EnableColision(true);
        container.Cow_paddock.EnableColision(true);
        container.Horse_paddock.EnableColision(true);
        container.Sheep_paddock.EnableColision(true);
        container.Chicken_paddock.EnableColision(true);
        ShowUi();
        container.inputMouse.InGame = true;
        container.Goose_paddock.StartDay();
        container.Goat_paddock.StartDay();
        container.Ostrich_paddock.StartDay();
        container.Pig_paddock.StartDay();
        container.Cow_paddock.StartDay();
        container.Horse_paddock.StartDay();
        container.Sheep_paddock.StartDay();
        container.Chicken_paddock.StartDay();
        animation.enabled = false;
        transform.position = new Vector3(-11.74f, 16f, -14.99f);

    }
    public void SwitchCameraPosition()
    {
        animation.enabled = true;
        animation.SetTrigger("StartCameraMove");
    }
    private void ShowUi()
    {
        foreach (var item in UiAnimation)
        {
            item.SetBool("ShowUi", true);
        }
        if(game_controller.Day == 0)
        {
            tutorial.StartFirstDayTutor(true);
        }
        if (game_controller.Day == 1)
        {
            tutorial.StartSecondDayTutor_1(true);
        }
        if(game_controller.Day != 0 && game_controller.Day != 1)
        {
            game_controller.DayIsActive = true;
        }
    }

    public void EndStartGameAnimation()
    {
        animation.enabled = false;
    }
    IEnumerator ShowStartUI()
    {
        yield return new WaitForSeconds(2.5f);
        Music._instance.NightIsOn();

        foreach (var item in UiAnimation)
        {
            item.SetBool("ShowUi", true);
        }
        yield return new WaitForSeconds(.5f);

        game_controller.AcivateFingerTutorial();
    }
}
