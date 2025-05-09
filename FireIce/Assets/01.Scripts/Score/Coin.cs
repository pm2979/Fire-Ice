using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("코인설정")]
    public ScoreConfig scoreConfig;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (scoreConfig.coinType == COINTYPE.FIRESTAR
            && !collision.CompareTag("PlayerFire"))
        {
            //파이어스타와 아이스플레이어를 만나면 없어지지 말기
            return;
        }
        else if (scoreConfig.coinType == COINTYPE.ICESTAR
            && !collision.CompareTag("PlayerIce"))
        {
            return;
        }
        ScoreManager.AddCoin(scoreConfig.coinScore, scoreConfig.coinType);
        Destroy(gameObject);
    }
}
