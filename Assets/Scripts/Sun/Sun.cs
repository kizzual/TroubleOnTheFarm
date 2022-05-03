using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    private StateMachine_sun _sm;
    [SerializeField] List<Light> lamps;

    public static Sun _instance;
    public bool animationIsStarting = false;
    public static int DayLengh;

    public Transform RotateTo;

    void Awake()
    {
        _sm = new StateMachine_sun();
        _instance = this;
        _sm.Initialize(new SunRise(this));

    }

    private void FixedUpdate()
    {

        _sm.currentState.FixedUpdate();
    }


    public void EarlyDayEnd()
    {
        _sm.ChangeState(new EarlyEndDay(this));

    }
    public void StartNight()
    {
        foreach (var item in lamps)
        {
            item.enabled = true;
        }
        _sm.ChangeState(new SunRise(this));
    }
    public void DayEnded()
    {
        
        _sm.ChangeState(new EndDay(this));
    }
    public void SunStart()
    {
        animationIsStarting = true;
    }
    public void StartDay()
    {
/*        foreach (var item in lamps)
        {
            item.enabled = false;
        }*/
        _sm.ChangeState(new StartDay(this, DayLengh));
    }
}
 