using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CostumeData
{
    public static string fireCostumeId;
    public static string iceCostumeId;

    static CostumeData()
    {
        fireCostumeId = PlayerPrefs.GetString("FireCostume", "Nothing");
        iceCostumeId = PlayerPrefs.GetString("IceCostume", "Nothing");
    }
}
