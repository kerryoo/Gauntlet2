using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateLibrary : MonoBehaviour
{
    public CharacterState currCharacterState;
    
    private IdleState m_IdleState;
    public IdleState IdleState
    {
        get
        {
            if (m_IdleState == null)
            {
                m_IdleState = new IdleState();
            }
            return m_IdleState;
        }
    }

    private WalkingState m_WalkingState;
    public WalkingState WalkingState
    {
        get
        {
            if (m_WalkingState == null)
            {
                m_WalkingState = new WalkingState();
            }
            return m_WalkingState;
        }
    }

    private SpecialMovementState m_SpecialMovementState;
    public SpecialMovementState SpecialMovementState
    {
        get
        {
            if (m_SpecialMovementState = null)
            {
                m_SpecialMovementState = new SpecialMovementState();
            }
            return m_SpecialMovementState;
        }
    }

    private void Awake()
    {

    }

    public void handleInput()
    {

    }

}
