using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AchievementManager : MonoBehaviour
{
    // 업적 목록
    private List<Achievement> achievements = new List<Achievement>();

    private void Start()
    {
        AddAchievement("무사 탈출","한 번도 죽지 않고 스테이지를 클리어 하세요.",0f,false);
        AddAchievement("","",0f,false);
        AddAchievement("","",0f,false);
    }




    // 업적을 추가하는 함수
    public void AddAchievement(string name, string description, float completionPercentage, bool isCompleted)
    {
        Achievement newAchievement = new Achievement(name, description, completionPercentage, isCompleted);
        achievements.Add(newAchievement);
    }

    // 업적을 업데이트하는 함수
    public void UpdateAchievementProgress(string name, float progress)
    {
        Achievement achievement = achievements.Find(x => x.name == name);
        if (achievement != null)
        {
            achievement.completionPercentage = progress;
            // 업적 진행률이 100%일 때 완료 처리
            if (progress >= 100)
            {
                achievement.isCompleted = true;
            }
        }
    }

    // 업적을 완료 처리하는 함수
    public void CompleteAchievement(string name)
    {
        Achievement achievement = achievements.Find(x => x.name == name);
        if (achievement != null && !achievement.isCompleted)
        {
            achievement.isCompleted = true;
        }
    }

    // 업적 정보를 반환하는 함수
    public List<Achievement> GetAchievements()
    {
        return achievements;
    }

    public void DeathCount(int deathCount)
    {
        if(deathCount == 0)
        {
            CompleteAchievement("무사 탈출");
        }
    }
}

// 업적 데이터를 저장하는 구조체 (또는 클래스)
public class Achievement
{
    public string name;
    public string description;
    public float completionPercentage;
    public bool isCompleted;

    public Achievement(string name, string description, float completionPercentage, bool isCompleted)
    {
        this.name = name;
        this.description = description;
        this.completionPercentage = completionPercentage;
        this.isCompleted = isCompleted;
    }
}

