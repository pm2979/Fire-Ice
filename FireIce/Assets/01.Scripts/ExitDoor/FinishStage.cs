using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishStage : MonoBehaviour
{
    public void Finish()
    {
        var scoreMg = FindObjectOfType<ScoreManager>();
        if (scoreMg != null) scoreMg.Rank();
    }
}
