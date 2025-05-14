using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AchievementUI : MonoBehaviour
{
    AchievementList achievementList;
    public TextMeshProUGUI[] AchieveNames;
    public TextMeshProUGUI rightNameText;
    public TextMeshProUGUI rightDescText;
    public GameObject[] onCheck;

    private void Start()
    {
        achievementList = AchievementList.Instance;
        for (int i = 0; i < achievementList.achievements.Count; i++)
        {
            Debug.Log($"[{i}] {achievementList.achievements[i].name} 완료 여부: {achievementList.achievements[i].isCompleted}");
        }
        for (int i = 0; i < achievementList.achievements.Count && i < AchieveNames.Length; i++)
        {
            AchieveNames[i].text = achievementList.achievements[i].name;
            if (achievementList.achievements[i].isCompleted == true)
            {
                onCheck[i].SetActive(true);
            }
        }


    }

    public void ShowAchievementInfo(int index)
    {
        if (index >= 0 && index < achievementList.achievements.Count)
        {
            rightNameText.text = achievementList.achievements[index].name;
            rightDescText.text = achievementList.achievements[index].description;
        }
    }
}
