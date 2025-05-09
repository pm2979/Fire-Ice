using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ScoreUI : MonoBehaviour
{
    //Canvas에 붙일 스크립트 
    //Find 함수를 통해 현재 씬에 있는 별 갯수 세기(스테이지 별 코인 갯수 다를 수 있어서)
    [Header("코인 수집 텍스트")]
    public TMP_Text fireStarText;
    public TMP_Text iceStarText;

    int fireTotal, iceTotal;
    int fireCollected, iceCollected;
    private void Awake()
    {
        // 씬에 떠있는 Coin 컴포넌트를 전부 찾기
        var allCoins = FindObjectsOfType<Coin>();

        // ScoreConfig.coinType 에 따라 목표치 계산
        fireTotal = allCoins.Count(c => c.scoreConfig.coinType == COINTYPE.FIRESTAR);
        iceTotal = allCoins.Count(c => c.scoreConfig.coinType == COINTYPE.ICESTAR);

        // UI에 초기값 표시
        UpdateUI();
    }

    public void HandleCoinTypeCollected(COINTYPE type)
    {
        // 획득 개수만 늘리고 UI 갱신
        switch (type)
        {
            case COINTYPE.FIRESTAR:
                fireCollected++;
                break;
            case COINTYPE.ICESTAR:
                iceCollected++;
                break;
        }
        UpdateUI();
    }
    private void UpdateUI()
    {
        fireStarText.text = $"{fireCollected} / {fireTotal}";
        iceStarText.text = $"{iceCollected} / {iceTotal}";
    }
}
