using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : CharacterState
{
    public JumpingState(InputControl inputControl) : base(inputControl)
    {
        stateID = StateID.Jumping;
    }

    public override int handleInput()
    {
        throw new System.NotImplementedException();
    }
}
