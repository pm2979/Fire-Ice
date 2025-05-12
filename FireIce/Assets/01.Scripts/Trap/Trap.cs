using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrapType { FireTrap, IceTrap, PoisonTrap }
public class Trap : MonoBehaviour
{
    public TrapType trapType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (trapType)
        {
            case TrapType.FireTrap:
                if (collision.CompareTag("PlayerIce"))
                {
                    GameOver();
                }
                break;

            case TrapType.IceTrap:
                if (collision.CompareTag("PlayerFire"))
                {
                    GameOver();
                }
                break;

            case TrapType.PoisonTrap:
                if (collision.CompareTag("PlayerFire") || collision.CompareTag("PlayerIce"))
                {
                    GameOver();
                }

                break;
        }
    }
    protected void GameOver()
    {
        var stageUI = FindObjectOfType<StageUIController>();
        if (stageUI != null) stageUI.GameOverUI();
    }
}

