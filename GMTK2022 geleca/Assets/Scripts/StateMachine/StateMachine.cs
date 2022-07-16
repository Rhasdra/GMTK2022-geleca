using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class StateMachine : MonoBehaviour
{
    public State currentState;
    public State[] states;

    bool isChanging = true;

    public UnityEvent OnStateChange;

    void Update()
    {
        if(isChanging == false)
        currentState.StateTick();
    }

    public void ChangeState(State newState)
    {
        isChanging = true;
        currentState.StateExit();
        currentState = newState;
        currentState.StateEnter();

        OnStateChange.Invoke();
        isChanging = false;
    }
}
