using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("코인설정")]
    public ScoreConfig scoreConfig;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreManager.AddCoin(scoreConfig.coinScore, scoreConfig.coinType);
        
        Destroy(gameObject);
    }
}
