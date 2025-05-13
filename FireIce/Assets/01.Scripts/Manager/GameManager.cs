using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private StageUIController uIController;
    protected override void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 새로운 씬이 로드될 때마다 호출
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
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
            Debug.Log("Esc 키 누름");
        }
    }
    public void GameOverUI()
    {
        if(uIController != null)
        {
            uIController.GameOverUI();
        }
    }

    
}
