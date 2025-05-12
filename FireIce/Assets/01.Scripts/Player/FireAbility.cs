using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class FireAbility : Ability
{
    protected override bool InputKeyAbility()
    {
        return Input.GetKeyDown(KeyCode.DownArrow);
    }

    protected override void HandleIFrozen(IFrozen frozen)
    {
        frozen.IsFrozenFalse();
    }

    protected override void InIcePool()
    {
        GameOver();
    }

    protected override void InFirePool()
    {
        Debug.Log("불 지나가는 중");
    }    
}



