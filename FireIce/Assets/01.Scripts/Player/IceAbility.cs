using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

public class IceAbility : Ability
{
    protected override bool InputKeyAbility()
    {
        return Input.GetKeyDown(KeyCode.S);
    }

    protected override void HandleIFrozen(IFrozen frozen)
    {
        frozen.IsFrozen = true;
    }

    protected override void InFirePool()
    {
        GameOver();
    }

    protected override void InIcePool()
    {
        Debug.Log("얼음 지나가는 중");
    }
}
