using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFrozen // �õ� ���� ������Ʈ
{
    public bool IsFrozen { get; set; } // �õ� ���� ����
    public GameObject IceObj { get; set; } // �õ� ǥ�� ������Ʈ

    public void IsFrozenTrue();
    public void IsFrozenFalse();
    public void FrozenActive(bool isIce); // ���¿� ���� ����
    // FrozenActive�� ���� ����

}