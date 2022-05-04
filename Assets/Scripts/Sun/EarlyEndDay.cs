using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarlyEndDay : SunState
{
    private Sun _sun { get; }

    public EarlyEndDay(Sun sun)
    {
        _sun = sun;
    }
    public override void Enter()
    {
        base.Enter();

    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
   //     _sun.transform.rotation = Quaternion.Slerp(_sun.transform.rotation, _sun.RotateTo.rotation, Time.fixedDeltaTime);
    //    _sun.animationIsStarting = false;

    }

}
 