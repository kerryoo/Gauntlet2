using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateLibrary : MonoBehaviour
{
    public CharacterState currCharacterState;
    public int currStateID;
    public InputControl inputControl;
    
    private IdleState m_IdleState;
    public IdleState IdleState
    {
        get
        {
            if (m_IdleState == null)
            {
                m_IdleState = new IdleState(inputControl, gameObject);
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
                m_WalkingState = new WalkingState(inputControl, gameObject);
            }
            return m_WalkingState;
        }
    }

    private WalkingBackState m_WalkingBackState;
    public WalkingBackState WalkingBackState
    {
        get
        {
            if (m_WalkingBackState == null)
            {
                m_WalkingBackState = new WalkingBackState(inputControl, gameObject);
            }
            return m_WalkingBackState;
        }
    }

    private SpecialMovementState m_SpecialMovementState;
    public SpecialMovementState SpecialMovementState
    {
        get
        {
            if (m_SpecialMovementState == null)
            {
                m_SpecialMovementState = new SpecialMovementState(inputControl, gameObject);
            }
            return m_SpecialMovementState;
        }
    }

    private ShieldingState m_ShieldingState;
    public ShieldingState ShieldingState
    {
        get
        {
            if (m_ShieldingState == null)
            {
                m_ShieldingState = new ShieldingState(inputControl, gameObject);
            }
            return m_ShieldingState;
        }
    }

    private JumpingState m_JumpingState;
    public JumpingState JumpingState
    {
        get
        {
            if (m_JumpingState == null)
            {
                m_JumpingState = new JumpingState(inputControl, gameObject);
            }
            return m_JumpingState;
        }
    }



    private void Awake()
    {
        inputControl = gameObject.GetComponent<InputControl>();
    }

    public void handleInput()
    {
        currStateID = currCharacterState.handleInput();
        switchCharacterState();

    }

    private void switchCharacterState()
    {
        switch (currStateID)
        {
            case StateID.Idle:
                currCharacterState = IdleState;
                break;
            case StateID.Walking:
                currCharacterState = WalkingState;
                break;
            case StateID.WalkingBack:
                currCharacterState = WalkingBackState;
                break;
            case StateID.SpecialMovement:
                currCharacterState = SpecialMovementState;
                break;
            case StateID.Shielding:
                currCharacterState = ShieldingState;
                break;
            case StateID.Jumping:
                currCharacterState = JumpingState;
                break;
        }
    }

}
