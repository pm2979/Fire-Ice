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

    //흐르는 시간 , 목표 클리어 시간 표시
    [Header("타이머")]
    public TMP_Text timerText;
    public TMP_Text targetTimeText;

    [Header("최종 등급")]
    public TMP_Text gradeText;

    int fireTotal, iceTotal;

    //처음에 목표 개수만 설정
    public void InitializeTotals(int fireTotal, int iceTotal, int targetTime)
    {
        this.fireTotal = fireTotal;
        this.iceTotal = iceTotal;

        fireStarText.text = $"0 / {fireTotal}";
        iceStarText.text = $"0 / {iceTotal}";

        int tm = targetTime / 60;
        int ts = targetTime % 60;
        targetTimeText.text = $"목표 시간: {tm:D2}:{ts:D2}";
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
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        timerText.text = $"{minutes:D2}:{seconds:D2}";
    }

    //최종 등급 표시
    public void DisplayGrade(GRADE grade)
    {
        gradeText.text = grade.ToString();
    }
}
