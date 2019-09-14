using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SwitchID
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

    public enum possibleCrowdControl
    {
        Stun,
        Slow,
        Silence,
        Disarm,
        Snare
    }

    public const int Stun = (int)possibleCrowdControl.Stun;
    public const int Slow = (int)possibleCrowdControl.Slow;
    public const int Silence = (int)possibleCrowdControl.Silence;
    public const int Disarm = (int)possibleCrowdControl.Disarm;
}
