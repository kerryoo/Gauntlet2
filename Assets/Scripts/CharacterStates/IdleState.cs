using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : CharacterState
{
    public IdleState(InputControl inputControl) : base(inputControl)
    {
        stateID = StateID.Idle;
    }

    public override int handleInput()
    {
        if (Mathf.Abs(inputControl.Vertical) >= 0.001 || Mathf.Abs(inputControl.Horizontal) >= 0.001)
        {
                
        }
        return StateID.Walking;
    }
    
}
