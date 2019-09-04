using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    public float Vertical;
    public float Horizontal;
    public Vector2 MouseInput;

    public bool Fire1;
    public bool AimingOn;
    public bool Testbutton;

    public bool Shield;
    public bool ActivatableItem;
    public bool CharacterInvOpen;
    

    public bool Firing;

    // Update is called once per frame
    void Update()
    {
        MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        Fire1 = Input.GetButton("Fire1");
        AimingOn = Input.GetButton("Fire2");
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        ActivatableItem = Input.GetKeyDown(KeyCode.R);
    }
}
