using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

public class IceAbility : Ability
{
    [SerializeField] private MonoBehaviour abilityComponent;
    private Ability ability;

    private void Awake()
    {
        ability = abilityComponent as Ability;
    }

    protected override bool InputKeyAbility()
    {
        return Input.GetKeyDown(KeyCode.S);
    }

    protected override void HandleIFrozen(IFrozen frozen)
    {
        base.HandleIFrozen(frozen);
        frozen.IsFrozen = true;
    }

    protected override void InFirePool()
    {
        base.InFirePool();
        GameOver();
    }

    protected override void InIcePool()
    {
        base.InIcePool();
        Debug.Log("얼음 지나가는 중");
    }
}
