using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterPlayer : MonoBehaviour
{
    public delegate void passiveActivities();
    private passiveActivities currActivities;

    private InputControl m_InputControl;
    public InputControl InputControl
    {
        get
        {
            if (m_InputControl == null)
            {
                m_InputControl = GetComponent<InputControl>();
            }
            return m_InputControl;
        }
    }

    private CharacterInventory m_characterInventory;
    public CharacterInventory CharacterInventory
    {
        get
        {
            if (m_characterInventory == null)
            {
                m_characterInventory = GetComponent<CharacterInventory>();
            }
            return m_characterInventory;
        }
    }

    //Multicast delegate that holds activities of characters that must be handled
    //when they are not active. Called in update loop.

    void Update()
    {
        currActivities();
    }

    public void handleAddCharacter(Character character)
    {
        currActivities += character.passiveActivities;
    }
}
