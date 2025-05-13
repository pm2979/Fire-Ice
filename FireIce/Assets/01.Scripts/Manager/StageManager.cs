using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public AchievementManager achievementManager;

    private int deathCount = 0;
    public void OnPlayerDeath()
    {
        deathCount++;
    }

    // 스테이지 시작 시 초기화
    public void OnStageStart()
    {
        deathCount = 0;
    }

    // 스테이지 클리어 시 호출
    public void OnStageClear()
    {
        if (deathCount == 0)
        {
            achievementManager.CompleteAchievement("무사 탈출");
        }
    }
}
