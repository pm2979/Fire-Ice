using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishStage : MonoBehaviour
{
    public void Finish()
    {
        GameManager.Instance.NotifyDoorOpened();
    }
}
