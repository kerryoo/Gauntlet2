using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterState
{
    protected InputControl inputControl;
    public int stateID { get; protected set; }

    public abstract int handleInput();

    protected CharacterState(InputControl inputControl)
    {
        this.inputControl = inputControl;
    }
  
}
