using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishStage : MonoBehaviour
{
    public GameObject endPanel;

    public void Finish()
    {
        Debug.Log("Finish");
        endPanel.gameObject.SetActive(true);
    }
}
