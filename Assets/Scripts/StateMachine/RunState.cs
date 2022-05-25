using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunState : State
{
    public float run_speed;
    private Vector3 fearPos;
    private Player Player { get; }
    public RunState(Player player)
    {
        Player = player;
    }

    public override void Enter()
    {
        base.Enter();
        Player._agent.speed = 1.7f;
  //      Debug.Log("ENTER RUN");
        Player._animation.Run_Animation();

        if (!Player.dayIsActive)
        {
            if (!Player.IsFearing && !Player.IsEating)
            {
                Player.FindNewNearZone();
                Player._agent.SetDestination(Player.randomPatrolingDestination);
            }
            else
            {
                if (Player.IsEating && Player.IsFearing || Player.IsFearing)
                {
                    fearPos = Player.fearZoneToRun.position;
                    Player._agent.SetDestination(Player.fearZoneToRun.position);
                }
                else if (!Player.IsFearing && Player.IsEating)
                {
                    Player._agent.SetDestination(Player.eatPoint);
                }
            }
        }
    }

    public override void Exit()
    {
        base.Exit();
   //     Debug.Log("EXIT RUN");

     //   Player._animation.Idle_Animation();
    }
    public override void Update()
    {
        base.Update();
        if (!Player.dayIsActive)
        {
            if (!Player.IsFearing && !Player.IsEating)
            {
                if (CheckDistance(Player._agent.pathEndPosition) < 0.1f)
                {
                    Player.SwitchState(this);
                }
            }
            else
            {
                if (Player.IsEating && Player.IsFearing || Player.IsFearing)
                {
                    if (CheckDistance(fearPos) < 0.1f)
                    {
                        Player.IsFearing = false;
                        Player.SwitchState(this);
                    }
                }
                else if (!Player.IsFearing && Player.IsEating)
                {
                    if (CheckDistance(Player._agent.pathEndPosition) < 0.1f)
                    {
                        Player.SwitchState(this);
                    }
                }
            }
        }
        else
        {
            if (CheckDistance(Player._agent.pathEndPosition) < 0.1f)
            {

                Player.dayIsActive = false;
                Player.SwitchState(this);
            }
        }
    }

    private float CheckDistance(Vector3 destination) => Vector3.Distance(Player.transform.position, destination);

}
