using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRise : SunState
{
    private Sun _sun { get; }
    private float _basePosition = 190f;
    private float _latePosition = 155f;
    private float _timer;

    public SunRise(Sun sun)
    {
        _sun = sun;
    }
    public override void Enter()
    {
        base.Enter();
        _timer = 0;
       _sun.transform.rotation = Quaternion.Euler(190, 60, 0);
    }   

    public override void Exit()
    {
        base.Exit();
        _sun.transform.rotation = Quaternion.Euler(155, 60, 0);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
       /* if (_sun.animationIsStarting)
        {
            _timer += Time.fixedDeltaTime;
            if (_timer <= 3f)
            {
                Quaternion rotationX = Quaternion.AngleAxis(0.23f, Vector3.left);
                _sun.transform.rotation *= rotationX;
                if(_timer >= 2.85f)
                {
                    _sun.StartDay();
                }
            }

        }*/
    }

}
