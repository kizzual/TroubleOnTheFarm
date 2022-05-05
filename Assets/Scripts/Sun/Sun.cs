using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField] List<Light> lamps;

    public static Sun _instance;
    [SerializeField] private Animator _animator;
    void Awake()
    {
        _instance = this;
    }



    public void EarlyDayEnd()
    {
        Music._instance.DayIsFinished();

        _animator.SetBool("DayEnd", true);
        _animator.SetBool("DayStart", false);
        StartCoroutine(LampsCondition(true));

    }
    public void SunStart()
    {
        _animator.SetBool("DayEnd", false);
        _animator.SetBool("DayStart", true);
        StartCoroutine(LampsCondition(false));

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
        }
        else
        {
            foreach (var item in lamps)
            {
                item.enabled = false;

            }
            Music._instance.DayIsOn();

        }


    }
}
 