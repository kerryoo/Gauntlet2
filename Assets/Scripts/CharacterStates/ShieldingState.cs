﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldingState : CharacterState
{
    public ShieldingState(InputControl inputControl) : base(inputControl)
    {
        stateID = StateID.Shielding;
    }

    public override int handleInput()
    {
        throw new System.NotImplementedException();
    }
}
