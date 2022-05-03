using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDay : SunState
{
    private Sun _sun { get; }
    private float _dayTime;
    private float _timer;
    private float _stepToRotate;
    public StartDay(Sun sun, float dayTime)
    {
        _sun = sun;
        _dayTime = dayTime;
    }
    public override void Enter()
    {
        base.Enter();
        _timer = 0;
        _sun.transform.rotation = Quaternion.Euler(155, 60, 0);
        _stepToRotate = 145 / (50 * _dayTime);
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (_sun.animationIsStarting)
        {
            _timer += Time.fixedDeltaTime;
            if (_timer <= _dayTime)
            {
                Quaternion rotationX = Quaternion.AngleAxis(_stepToRotate, Vector3.left);
                _sun.transform.rotation *= rotationX;

                if (_timer >= _dayTime- .2f)
                {
                    _sun.DayEnded();
                      _sun.animationIsStarting = false;
                }
            }
        }
    }

}
