using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("���μ���")]
    public ScoreConfig scoreConfig;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (scoreConfig.coinType == COINTYPE.FIRESTAR
            && !collision.CompareTag("PlayerFire"))
        {
            //���̾Ÿ�� ���̽��÷��̾ ������ �������� ����
            return;
        }
        else if (scoreConfig.coinType == COINTYPE.ICESTAR
            && !collision.CompareTag("PlayerIce"))
        {
            return;
        }
        ScoreManager.AddCoin(scoreConfig.coinType);
        SoundManager.Instance.PlaySound(SOUNDTYPE.SFX, "match");
        Destroy(gameObject);
    }
}
