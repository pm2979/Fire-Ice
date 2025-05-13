using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public TRAPTYPE trapType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (trapType)
        {
            case TRAPTYPE.FIRETRAP:
                if (collision.CompareTag("PlayerIce"))
                {
                    GameOver();
                }
                break;

            case TRAPTYPE.ICETRAP:
                if (collision.CompareTag("PlayerFire"))
                {
                    GameOver();
                }
                break;

            case TRAPTYPE.POISONTRAP:
                if (collision.CompareTag("PlayerFire") || collision.CompareTag("PlayerIce"))
                {
                    GameOver();
                }

                break;
        }
    }
    protected void GameOver()
    {
        //GameManager.Instance.GameOverUI();
    }
}

