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

    //단순히 게임 시작 후 시간이 흘러감을 표시
    [Header("타이머")]
    public TMP_Text timerText;

    [Header("최종 등급")]
    public TMP_Text gradeText;

    int fireTotal, iceTotal;

    //처음에 목표 개수만 설정
    public void InitializeTotals(int fireTotal, int iceTotal)
    {
        this.fireTotal = fireTotal;
        this.iceTotal = iceTotal;
        fireStarText.text = $"0 / {fireTotal}";
        iceStarText.text = $"0 / {iceTotal}";
    }

    //코인 획득 개수 업데이트
    public void UpdateCoinUI(int fireCollected, int iceCollected)
    {
        fireStarText.text = $"{fireCollected} / {fireTotal}";
        iceStarText.text = $"{iceCollected} / {iceTotal}";
    }

    //경과 시간 표시
    public void UpdateTimer(float elapsedTime)
    {
        timerText.text = $"{elapsedTime:F1}";
    }

    //최종 등급 표시
    public void DisplayGrade(GRADE grade)
    {
        gradeText.text = grade.ToString();
    }
}
