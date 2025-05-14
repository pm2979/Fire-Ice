using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishStage : MonoBehaviour
{
    public void Finish()
    {
        GameManager.Instance.NotifyDoorOpened();
        SoundManager.Instance.PlaySound(SoundType.SFX, "08_human_charge_2");
    }
}
