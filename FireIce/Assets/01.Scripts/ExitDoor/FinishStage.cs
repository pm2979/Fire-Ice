using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishStage : MonoBehaviour
{
    public void OnPlus1()
    {
        GameManager.Instance.NotifyDoorOpened();
    }
    public void OnMinus1()
    {
        GameManager.Instance.NotifyDoorClosed();
    }
}
