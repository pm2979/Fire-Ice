using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class AchievementConditions : MonoBehaviour
{
    ScoreUI scoreUI;
    public int deathCount = 0;
    AchievementList achievementList;
    AchievementUI achievementUI;

    private void Start()
    {
        deathCount = 0;

    }
    public void OnCheckAchievement()
    {

        
    }
    public void CheckNoDeathClear()
    {
        if(deathCount == 0)
        {
            achievementList = FindObjectOfType<AchievementList>();
            deathCount = 0;
            achievementList.achievements[0].isCompleted = true;
        }   
    }
}
