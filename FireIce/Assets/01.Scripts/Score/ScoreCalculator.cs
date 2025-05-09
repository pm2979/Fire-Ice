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
    
    //코인 타입 전달
    float coinTotalScore = 0f;
    public float CoinTotalScore => coinTotalScore;

    public void TotalScore(float coinScore)
    {
        coinTotalScore += coinScore;
        Debug.Log($"누적 코인점수 : {coinTotalScore}");
    }
    public void ResetScore()
    {
        coinTotalScore = 0f;
    }
}
