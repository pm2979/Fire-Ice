using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class FireAbility : Ability
{
    protected override bool InputKeyAbility()
    {
        return Input.GetKeyDown(KeyCode.DownArrow); //다운 키 : 아래 화살표
    }

    protected override void HandleIFrozen(IFrozen frozen)  //IFrozen과 충돌 시 IsFrozenFalse() 실행
    {
        frozen.IsFrozenFalse();
    }

    protected override void InIcePool() //얼음과 충돌 시 게임 오버
    {
        GameOver();
    }

    protected override void InFirePool()
    {
        Debug.Log("불 지나가는 중");
    }    
}



