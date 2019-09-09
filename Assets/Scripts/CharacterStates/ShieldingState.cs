using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldingState : CharacterState 
{
    public ShieldingState(InputControl inputControl, GameObject gameObject) : base(inputControl, gameObject)
    {
        stateID = StateID.Shielding;
    }

    public override int handleInput()
    {
        throw new System.NotImplementedException();
    }
}
