using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    //플레이어가 코인과 충돌하면
    //충돌한 코인의 score를 받아오기
    //나중에 시간 점수도 받을 예정 
    //최종 점수도 계산
    
    //이벤트버스 구독 방식 사용해봄
    public static event Action<float> OnAddCoin;
    [SerializeField] private float coinTotalScore = 0f;

    private void OnEnable()
    {
        OnAddCoin += CoinCollected;
    }
    private void OnDisable()
    {
        OnAddCoin -= CoinCollected;
    }
    public static void AddCoin(float coinScore)
    {
        OnAddCoin?.Invoke(coinScore);
    }
    private void CoinCollected(float coinScore)
    {
        coinTotalScore += coinScore;
        Debug.Log($"누적 코인점수 : {coinTotalScore}");
    }
    public void ResetScore()
    {
        coinTotalScore = 0f;
    }
}
