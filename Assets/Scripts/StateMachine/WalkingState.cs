using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : State
{
    private Player Player { get; }

    public WalkingState (Player player)
    {
        Player = player;
    }

    public override void Enter()
    {
        base.Enter();
        Player._agent.speed = 0.7f;

        Player._agent.SetDestination(Player.randomPatrolingDestination);

        Player._animation.Walk_Animation();
    }

    public override void Exit()
    {
        base.Exit();
        Player._animation.Idle_Animation();

    }
    public override void Update()
    {
        base.Update();
       if(Vector3.Distance(Player.transform.position, Player._agent.pathEndPosition) < 0.1)
        {
            Player.SwitchState(this);
        }
    }

}
