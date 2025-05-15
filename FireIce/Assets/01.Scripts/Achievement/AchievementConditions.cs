using UnityEngine;

public class AchievementConditions : MonoBehaviour
{
    public int deathCount = 0;

    private void Start()
    {
        deathCount = 0;
    }

    public void CheckNoDeathClear() // ���� Ŭ���� Ȯ��
    {
        if(deathCount == 0)
        {
            
            deathCount = 0;
            AchievementManager.Instance.achievements[0].isCompleted = true;
        }
        AchievementAllClear();
    }

    private void OnEnable()
    {
        ScoreManager.OnStageCleared += HandleStageClear;
    }

    private void OnDisable()
    {
        ScoreManager.OnStageCleared -= HandleStageClear;
    }

    public void HandleStageClear(GRADE grade) // ���� Ŭ���� Ȯ��
    {
        if (grade == GRADE.A)
        {
            AchievementManager.Instance.achievements[1].isCompleted = true;
        }
        AchievementAllClear();
    }

    public void AchievementAllClear() // ���� Ŭ���� Ȯ��
    {
        for (int i = 0; i < AchievementManager.Instance.achievements.Count-1; i++)
        {
            if (!AchievementManager.Instance.achievements[i].isCompleted)
            {
                return;
            }
        }
        AchievementManager.Instance.achievements[AchievementManager.Instance.achievements.Count - 1].isCompleted = true;
    }
}
