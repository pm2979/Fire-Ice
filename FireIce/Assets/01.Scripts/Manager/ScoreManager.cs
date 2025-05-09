using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //이벤트 구독 방식 사용
    public static event Action<float> OnAddCoin;
    public static event Action<COINTYPE> OnCoinType;

    [SerializeField] ScoreCalculator scoreCalculator;
    [SerializeField] ScoreUI scoreUI;

    private void OnEnable()
    {
        OnAddCoin += scoreCalculator.TotalScore;
        OnCoinType += scoreUI.HandleCoinTypeCollected;
    }
    private void OnDisable()
    {
        OnAddCoin -= scoreCalculator.TotalScore;
        OnCoinType -= scoreUI.HandleCoinTypeCollected;
    }

    public static void CoinCollected(float amount, COINTYPE type)
    {
        OnAddCoin?.Invoke(amount);
        OnCoinType?.Invoke(type);
    }
}
