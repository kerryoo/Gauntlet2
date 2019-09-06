using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : CharacterState
{
    public IdleState(InputControl inputControl, GameObject gameObject) : base(inputControl, gameObject)
    {
        stateID = StateID.Idle;
    }

    public override int handleInput()
    {
        if (inputControl.Jumping)
        {
            return StateID.Jumping;
        }
        if (inputControl.Vertical >= 0.001 || Mathf.Abs(inputControl.Horizontal) >= 0.001)
        {
            return StateID.Walking;
        }
        if (inputControl.Vertical <= 0.001)
        {
            return StateID.WalkingBack;
        }

        return StateID.Idle;
    }


    private void Move()
    {

    }
    
}
