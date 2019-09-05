using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : CharacterState
{
    public WalkingState(InputControl inputControl) : base(inputControl)
    {
        stateID = StateID.Walking;
    }


    public override int handleInput()
    {
        throw new System.NotImplementedException() ;
    }
}
