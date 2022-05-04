using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
 //   private StateMachine_sun _sm;
    [SerializeField] List<Light> lamps;

    public static Sun _instance;
 //   public bool animationIsStarting = false;
  //  public static int DayLengh;

  //  public Transform RotateTo;
    [SerializeField] private Animator _animator;
    void Awake()
    {
     //   _sm = new StateMachine_sun();
        _instance = this;
        //    _sm.Initialize(new SunRise(this));
        _animator.SetBool("DayEnd", true);
        _animator.SetBool("DayStart", false);
        StartCoroutine(LampsCondition(true));
    }

    private void FixedUpdate()
    {

     //   _sm.currentState.FixedUpdate();
    }


    public void EarlyDayEnd()
    {
        //    _sm.ChangeState(new EarlyEndDay(this));
        Music._instance.DayIsFinished();

        _animator.SetBool("DayEnd", true);
        _animator.SetBool("DayStart", false);
        StartCoroutine(LampsCondition(true));

    }
    public void StartNight()
    {
/*        foreach (var item in lamps)
        {
            item.enabled = true;
        }
        _sm.ChangeState(new SunRise(this));*/
    }
    public void DayEnded()
    {
        
   //     _sm.ChangeState(new EndDay(this));
    }
    public void SunStart()
    {
        //     animationIsStarting = true;
        _animator.SetBool("DayEnd", false);
        _animator.SetBool("DayStart", true);
        StartCoroutine(LampsCondition(false));

    }
    public void StartDay()
    {

        /*        foreach (var item in lamps)
                {
                    item.enabled = false;
                }*/
        //    _sm.ChangeState(new StartDay(this, DayLengh));
    }
    IEnumerator LampsCondition ( bool isOn)
    {
        yield return new WaitForSeconds(2.3f);
        if(isOn)
        {
            foreach (var item in lamps)
            {
                item.enabled = true;

            }
       //     yield return new WaitForSeconds(1f);
        }
        else
        {
            foreach (var item in lamps)
            {
                item.enabled = false;

            }
    //        yield return new WaitForSeconds(1f);
            Music._instance.DayIsOn();

        }


    }
}
 