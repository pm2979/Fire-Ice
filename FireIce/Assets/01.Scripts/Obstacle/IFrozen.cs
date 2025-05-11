using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFrozen // 장애물 활성화
{
    public bool IsFrozen { get; set; }
    public GameObject IceObj { get; set; }

    public void IsFrozenTrue();
    public void IsFrozenFalse();
    public void IsIceActive(bool isIce);

}