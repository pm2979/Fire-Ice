using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class FireAbility : Ability
{
    [SerializeField] private MonoBehaviour abilityComponent;
    private Ability ability;

    private void Awake()
    {
        ability = abilityComponent as Ability;
    }

    protected override bool InputKeyAbility()
    {
        return Input.GetKeyDown(KeyCode.DownArrow);
    }

    protected override void HandleIFrozen(IFrozen frozen)
    {
        base.HandleIFrozen(frozen);
        frozen.IsFrozen = false;
    }

    protected override void InIcePool()
    {
        base.InIcePool();
        GameOver();
    }

    protected override void InFirePool()
    {
        base.InFirePool();
        Debug.Log("불 지나가는 중");
    }    
}



