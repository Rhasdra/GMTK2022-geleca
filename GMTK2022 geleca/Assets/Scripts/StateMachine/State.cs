using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour
{
    public UnityEvent OnStateEnter;
    public UnityEvent OnStateTick;
    public UnityEvent OnStateExit;

    public virtual void StateEnter()
    {
        OnStateEnter.Invoke();
    }

    public virtual void StateTick()
    {
        OnStateTick.Invoke();
    }

    public virtual void StateExit()
    {
        OnStateExit.Invoke();
    }
}
