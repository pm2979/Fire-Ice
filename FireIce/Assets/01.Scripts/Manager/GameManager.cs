using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private StageUIController uIController;
    private int totalDoor;
    private int openDoor;

    protected override void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 새로운 씬이 로드될 때마다 호출
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        var doors = FindObjectsOfType<ExitDoor>();
        totalDoor = doors.Length;
        openDoor = 0;
        uIController = FindObjectOfType<StageUIController>();
    }

    private void Update()
    {
        if(uIController != null)
        {
            ESC();
        }
    }

    private void ESC()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            uIController.OnEscape();
        }
    }

    public void GameOverUI()
    {
        //var achvcond = FindObjectOfType<AchievementConditions>();
        FindObjectOfType<AchievementConditions>().deathCount++;
        if (uIController != null)
        {
            uIController.GameOverUI();
        }


    }
    public void NotifyDoorOpened()
    {
        openDoor = Mathf.Min(openDoor + 1, totalDoor);
        TryCheckAllDoorsOpen();
    }

    public void NotifyDoorClosed()
    {
        openDoor = Mathf.Max(openDoor - 1, 0);
    }

    private void TryCheckAllDoorsOpen()
    {
        if (openDoor >= totalDoor)
        {
            // 모든 문이 열려야 이 부분 한 번 실행
            var achvcond = FindObjectOfType<AchievementConditions>();
            var scoreMg = FindObjectOfType<ScoreManager>();
            if (scoreMg != null && achvcond != null)
            {
                scoreMg.Rank();
                achvcond.CheckNoDeathClear();
            }
        }
    }
}
