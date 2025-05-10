using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltingPlatform : MonoBehaviour , IIceActive
{
    [field: SerializeField] public bool IsIce { get; set; } = false;
    [field: SerializeField] public GameObject IceObj { get; set; }
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        IsIceActive(IsIce);
    }

    public void IsIceTrue()
    {
        IsIce = true;
        IsIceActive(IsIce);
    }

    public void IsIceFalse()
    {
        IsIce = false;
        IsIceActive(IsIce);
    }

    public void IsIceActive(bool isIce)
    {
        rb.freezeRotation = isIce;
        IceObj.SetActive(isIce);
    }
}
