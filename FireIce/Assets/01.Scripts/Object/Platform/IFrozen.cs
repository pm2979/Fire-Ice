using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFrozen // 냉동 가능 오브젝트
{
    public bool IsFrozen { get; set; } // 냉동 상태 여부
    public GameObject IceObj { get; set; } // 냉동 표시 오브젝트

    public void IsFrozenTrue();
    public void IsFrozenFalse();
    public void FrozenActive(bool isIce); // 상태에 따라 실행
    // FrozenActive로 변경 예정

}