using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private Player Player { get; }

    private float timeToStay;

    float timer;
    public IdleState(Player player)
    {
        Player = player;
    }

    public override void Enter()
    {
        base.Enter();
        if (Player.IsEating)
            Player._animation.Eat_Animation();
        else
            Player._animation.Idle_Animation();


        timeToStay = Random.Range(2, 5);
        timer = 0;



    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(!Player.IsEating)
        {
            timer += Time.deltaTime;

            if (timer > timeToStay)       
                Player.SwitchState(this);
        }
        
    }
}
