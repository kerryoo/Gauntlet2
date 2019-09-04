using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateLibrary : MonoBehaviour
{
    IdleState idleState;
    WalkingState walkingState;

    private void Awake()
    {
        idleState = new IdleState();
        walkingState = new WalkingState();


    }

    public void handleInput()
    {

    }

}
