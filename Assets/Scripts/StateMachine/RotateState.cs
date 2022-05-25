using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateState : State
{
    private Player Player { get; }
    private float rotateSpeed = 0.1f;
    private float timer;
    private float angleToRotate;
    public RotateState(Player player)
    {
        Player = player;
    }

    public override void Enter()
    {
        base.Enter();
        timer = 0;
        Player._animation.Idle_Animation();
        if (!Player.dayIsActive)
        {

            if (Player.IsFearing)
            {
                CheckAngleToRotateFromFear();
            }
        }
   //     Debug.Log("enter rotate state");
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        timer += Time.deltaTime;
        if (!Player.dayIsActive)
        {
            if (Player.IsFearing)
            {
                Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, Quaternion.Euler(0, angleToRotate, 0), rotateSpeed);
                if (timer > 0.3f)
                    Player.SwitchState(this);
            }

            else if (Player.IsEating && !Player.IsFearing)
            {
                Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, Quaternion.LookRotation(Player.eatPoint - Player.transform.position), rotateSpeed);
                if (timer > 0.3f)
                {
                    Player.SwitchState(this);
                }
            }
            else
            {
                Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, Quaternion.LookRotation(Player.randomPatrolingDestination - Player.transform.position), rotateSpeed);
                if (timer > 0.3f)
                    Player.SwitchState(this);
            }
        }
        else
        {
            Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, Quaternion.LookRotation(Player.randomPatrolingDestination - Player.transform.position), rotateSpeed);
            if (timer > 0.3f)
                Player.RunAway();
        }
    }
    private void CheckAngleToRotateFromFear()
    {
        Vector3 targetPos = Player.pointFromFear.position;
        targetPos.y = Player.transform.position.y;

        Vector3 direction = targetPos - Player.transform.position;
        angleToRotate = Quaternion.LookRotation(direction, Vector3.up).eulerAngles.y + 180;

        float angleBetween = Vector3.SignedAngle(direction, Player.transform.forward, Vector3.up);

        if (Mathf.Abs(angleBetween) > 165)
        {
            Player.SwitchState(this);
        }
    }
 
}
