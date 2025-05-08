using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private GameObject ObstacleObj;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ObstacleObj.GetComponent<ISwitchActive>().Active();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        ObstacleObj.GetComponent<ISwitchActive>().Deactive();
    }
}
