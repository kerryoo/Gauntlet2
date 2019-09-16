using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterPlayer : MonoBehaviour
{
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








    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
