using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAbility : Ability
{
    protected override bool InputKeyAbility() //다운 키 : S
    {
        return Input.GetKeyDown(KeyCode.S);
    }

    protected override void HandleIFrozen(IFrozen frozen) //IFrozen과 충돌 시 IsFrozenTrue() 실행
    {
        frozen.IsFrozenTrue();
    }

    protected override void InFirePool() //불에 닿이면 게임 오버
    {
        GameOver();
    }

    protected override void InIcePool()
    {
        Debug.Log("얼음 지나가는 중");
    }
}
