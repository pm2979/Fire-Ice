using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AchievementUI : MonoBehaviour
{
    AchievementManager achievementManager;
    public TextMeshProUGUI[] AchieveNames;
    public TextMeshProUGUI rightNameText;
    public TextMeshProUGUI rightDescText;
    public GameObject[] onCheck;

    private void Start()
    {
        achievementManager = AchievementManager.Instance;
        for (int i = 0; i < achievementManager.achievements.Count; i++)
        {
            Debug.Log($"[{i}] {achievementManager.achievements[i].name} 완료 여부: {achievementManager.achievements[i].isCompleted}");
        }
        for (int i = 0; i < achievementManager.achievements.Count && i < AchieveNames.Length; i++)
        {
            AchieveNames[i].text = achievementManager.achievements[i].name;
            if (achievementManager.achievements[i].isCompleted == true)
            {
                onCheck[i].SetActive(true);
            }
        }
    }

    public void ShowAchievementInfo(int index)
    {
        if (index >= 0 && index < achievementManager.achievements.Count)
        {
            rightNameText.text = achievementManager.achievements[index].name;
            rightDescText.text = achievementManager.achievements[index].description;
        }
    }
}
