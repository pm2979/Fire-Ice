using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AchievementManager : MonoBehaviour
{
    public TextMeshProUGUI[] AchieveNames;
    public TextMeshProUGUI rightNameText;
    public TextMeshProUGUI rightDescText;




    // 업적 목록
    private List<AchievementList> achievements = new List<AchievementList>();

    private void Start()
    {
        AddAchievement("무사 탈출","한 번도 죽지 않고 스테이지를 클리어 하세요.",0f,false);
        AddAchievement("123","1234",0f,false);
        AddAchievement("14","135",0f,false);

        for (int i = 0; i<achievements.Count&& i<AchieveNames.Length; i++)
        {
            AchieveNames[i].text = achievements[i].name;
        }


    }

    public void ShowAchievementInfo(int index)
    {
        if (index >= 0 && index < achievements.Count)
        {
            rightNameText.text = achievements[index].name;
            rightDescText.text = achievements[index].description;
        }
    }


    // 업적 추가
    public void AddAchievement(string name, string description, float completionPercentage, bool isCompleted)
    {
        AchievementList newAchievement = new AchievementList(name, description, completionPercentage, isCompleted);
        achievements.Add(newAchievement);
    }

    // 업적 업데이트
    public void UpdateAchievementProgress(string name, float progress)
    {
        AchievementList achievement = achievements.Find(x => x.name == name);
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

    // 업적 완료
    public void CompleteAchievement(string name)
    {
        AchievementList achievement = achievements.Find(x => x.name == name);
        if (achievement != null && !achievement.isCompleted)
        {
            achievement.isCompleted = true;
        }
    }

    // 업적 정보 반환
    public List<AchievementList> GetAchievements()
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
public class AchievementList
{
    public string name;
    public string description;
    public float completionPercentage;
    public bool isCompleted;

    public AchievementList(string name, string description, float completionPercentage, bool isCompleted)
    {
        this.name = name;
        this.description = description;
        this.completionPercentage = completionPercentage;
        this.isCompleted = isCompleted;
    }
}

