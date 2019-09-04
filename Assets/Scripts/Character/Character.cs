using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private CharacterState currCharacterState;
    private CharacterStats characterStats;
    private InputControl inputControl;

    public void handleInput()
    {
        currCharacterState.handleInput();
    }

    private void move()
    {
      
    }
}
