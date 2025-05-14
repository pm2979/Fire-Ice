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
        FrozenActive(IsFrozen);
    }

    public void IsFrozenTrue()
    {
        IsFrozen = true;
        FrozenActive(IsFrozen);
    }

    public void IsFrozenFalse()
    {
        IsFrozen = false;
        FrozenActive(IsFrozen);
    }

    public void FrozenActive(bool isIce)
    {
        rb.freezeRotation = isIce;
        IceObj.SetActive(isIce);
    }
}
