using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CharacterState
{
    CharacterState handleInput(InputControl inputControl);
    InputControl getInputControl
    
}
