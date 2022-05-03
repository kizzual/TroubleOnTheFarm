using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDay : SunState
{
    private Sun _sun { get; }
    private float _timer;
    public EndDay(Sun sun)
    {
        _sun = sun;
    }
    public override void Enter()
    {
        base.Enter();
        _sun.transform.rotation = Quaternion.Euler(10, 60, 0);

    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        _timer += Time.fixedDeltaTime;

        if (_timer <= 1)
        {
            Quaternion rotationX = Quaternion.AngleAxis(0.3f, Vector3.left);
            _sun.transform.rotation *= rotationX;
        }
    }

}
