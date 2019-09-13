using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StateID
{
    public enum possibleStates
    {
        Idle,
        Walking,
        WalkingBack,
        SpecialMovement,
        Shielding,
        Jumping
    }


    public const int Idle = (int)possibleStates.Idle;
    public const int Walking = (int)possibleStates.Walking;
    public const int WalkingBack = (int)possibleStates.WalkingBack;
    public const int SpecialMovement = (int)possibleStates.SpecialMovement;
    public const int Shielding = (int)possibleStates.Shielding;
    public const int Jumping = (int)possibleStates.Jumping;
}
