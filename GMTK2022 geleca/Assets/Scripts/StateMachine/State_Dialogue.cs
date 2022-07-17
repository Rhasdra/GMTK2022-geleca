using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Dialogue : State
{
    [SerializeField] GameObject clickbox;

    public override void StateEnter()
    {
        base.StateEnter();

        clickbox.SetActive(true);
    }

    public override void StateExit()
    {
        base.StateExit();

        clickbox.SetActive(false);
    }

}
