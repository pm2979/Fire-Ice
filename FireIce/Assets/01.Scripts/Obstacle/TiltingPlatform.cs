using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltingPlatform : MonoBehaviour ,IFrozen
{
    [field: SerializeField] public bool IsFrozen { get; set; } = false;
    [field: SerializeField] public GameObject IceObj { get; set; }
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        IsIceActive(IsFrozen);
    }

    public void IsFrozenTrue()
    {
        IsFrozen = true;
        IsIceActive(IsFrozen);
    }

    public void IsFrozenFalse()
    {
        IsFrozen = false;
        IsIceActive(IsFrozen);
    }

    public void IsIceActive(bool isIce)
    {
        rb.freezeRotation = isIce;
        IceObj.SetActive(isIce);
    }
}
