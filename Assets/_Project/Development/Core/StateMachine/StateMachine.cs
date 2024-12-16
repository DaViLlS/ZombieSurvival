using System.Collections.Generic;
using System;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected IState _currentState;
    protected Dictionary<StateType, IState> _stateHandlers;

    public StateMachine(IState currentState, Dictionary<StateType, IState> stateHandlers)
    {
        _currentState = currentState;
        _stateHandlers = stateHandlers;
    }

    private void Update()
    {
        TriggerEvent();
    }

    public void TriggerEvent()
    {
        _currentState.Execute();
    }
}
