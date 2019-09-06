using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMovementState : CharacterState
{
    public SpecialMovementState(InputControl inputControl, GameObject gameObject) : base(inputControl, gameObject)
    {
        stateID = StateID.SpecialMovement;
    }

    public override int handleInput()
    {
        throw new System.NotImplementedException();
    }
}
