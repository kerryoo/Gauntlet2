using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingBackState : CharacterState
{
    public WalkingBackState(InputControl inputControl) : base(inputControl)
    {
        stateID = StateID.WalkingBack;
    }

    public override int handleInput()
    {
        throw new System.NotImplementedException();
    }
}
