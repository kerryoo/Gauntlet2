using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : CharacterState
{
    public CharacterState handleInput(InputControl inputControl)
    {
        if (Mathf.Abs(inputControl.Vertical) >= 0.001 || Mathf.Abs(inputControl.Horizontal) >= 0.001)
        {
                
        }


        return new IdleState();

    }
    
}
