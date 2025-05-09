using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("코인설정")]
    public ScoreConfig scoreConfig;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (scoreConfig.coinType)
        {
            // FIRESTAR는 PlayerFire만
            case COINTYPE.FIRESTAR:
                if (collision.CompareTag("PlayerFire")) break;
                return;

            // ICESTAR는 PlayerIce만
            case COINTYPE.ICESTAR:
                if (collision.CompareTag("PlayerIce")) break;
                return;

            // 나머지(GOLD/SILVER/BRONZE)는 모두 허용
            default:
                break;
        }
        ScoreCalculator.AddCoin(scoreConfig.coinScore);
        Destroy(gameObject);
    }
}
