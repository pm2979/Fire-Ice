using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AchievementManager : Singleton<AchievementManager>
{
    public List<Achievement> achievements = new List<Achievement>(); // ���� ���

    protected override void Awake()
    {
        AddAchievement("���� Ż��", "�� ���� ���� �ʰ� ���������� Ŭ���� �ϼ���.", 0f, false);
        AddAchievement("A��ũ Ŭ����", "A��ũ�� Ŭ���� �ϼ���.", 0f, false);
        AddAchievement("����������", "��� ���� Ŭ����.", 0f, false);
    }

    // ���� �߰�
    public void AddAchievement(string name, string description, float completionPercentage, bool isCompleted)
    {
        Achievement newAchievement = new Achievement(name, description, completionPercentage, isCompleted);
        achievements.Add(newAchievement);
    }


    // ���� ������Ʈ
    public void UpdateAchievementProgress(string name, float progress)
    {
        Achievement achievement = achievements.Find(x => x.name == name);
        if (achievement != null)
        {
            achievement.completionPercentage = progress;
            // ���� ������� 100%�� �� �Ϸ� ó��
            if (progress >= 100)
            {
                achievement.isCompleted = true;
            }
        }
    }

    // ���� �Ϸ�
    public void CompleteAchievement(string name)
    {
        Achievement achievement = achievements.Find(x => x.name == name);
        if (achievement != null && !achievement.isCompleted)
        {
            achievement.isCompleted = true;
        }
    }

    // ���� ���� ��ȯ
    public List<Achievement> GetAchievements()
    {
        return achievements;
    }

}

// ���� �����͸� �����ϴ� ����ü (�Ǵ� Ŭ����)
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





