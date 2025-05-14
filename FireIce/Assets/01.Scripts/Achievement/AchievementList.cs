using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AchievementList : MonoBehaviour
{
    public static AchievementList Instance;


    public List<Achievement> achievements = new List<Achievement>(); // 업적 목록

    private void Awake()
    {

    }
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            SceneManager.sceneLoaded += OnSceneLoaded; //씬 바뀔때마다 호출
        }
        else
        {
            Destroy(gameObject);
        }

        AddAchievement("무사 탈출", "한 번도 죽지 않고 스테이지를 클리어 하세요.", 0f, false);
        AddAchievement("A랭크 클리어", "A랭크로 클리어 하세요.", 0f, false);
        AddAchievement("업적마스터", "모든 업적 클리어.", 0f, false);

    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 같은 이름을 가진 오브젝트 제거
        GameObject[] duplicates = GameObject.FindGameObjectsWithTag("Achievement");
        foreach (GameObject obj in duplicates)
        {
            if (obj != this.gameObject)
            {
                Destroy(obj);
            }
        }
    }

    // 업적 추가
    public void AddAchievement(string name, string description, float completionPercentage, bool isCompleted)
    {
        Achievement newAchievement = new Achievement(name, description, completionPercentage, isCompleted);
        achievements.Add(newAchievement);
    }


    // 업적 업데이트
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

    // 업적 완료
    public void CompleteAchievement(string name)
    {
        Achievement achievement = achievements.Find(x => x.name == name);
        if (achievement != null && !achievement.isCompleted)
        {
            achievement.isCompleted = true;
        }
    }

    // 업적 정보 반환
    public List<Achievement> GetAchievements()
    {
        return achievements;
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