using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine_sun 
{
    public SunState currentState { get; set; }

    public void Initialize(SunState startState)
    {
        currentState = startState;
        currentState.Enter();
    }
    public void ChangeState(SunState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
