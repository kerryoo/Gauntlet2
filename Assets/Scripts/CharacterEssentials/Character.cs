using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private CharacterState _currCharacterState;
    private InputControl _inputControl;

    public CharacterStats CharacterStats;
    public GameObject CharacterModel;

    public void handleInput()
    {
        _currCharacterState.handleInput();
    }
}
