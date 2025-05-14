using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class StageUIController : MonoBehaviour
{
    //스테이지에서 일시정지, 클리어 흐름과 ui를 담당합니다.

    [Header("UI 패널")]
    public GameObject pauseUI;
    public GameObject clearUI;
    public GameObject gameoverUI;
    public GameObject escapeUI;

    [Header("최종 등급 애니메이션")]
    [SerializeField] private Animator gradeAnim;

    [Header("등급 표시용 UI")]
    [SerializeField] private Image gradeImage;
    [SerializeField] private Sprite[] gradeSprites;// A,B,C 

    [Header("조건 체크 아이콘")]
    [SerializeField] private Image timeCheckIcon;
    [SerializeField] private Image coinCheckIcon;
    [SerializeField] private Sprite checkSprite;         
    [SerializeField] private Sprite crossSprite;


    public struct RankResult
    {
        public GRADE Grade;       // A, B, C
        public bool TimeSuccess;  // 시간 조건 달성 여부
        public bool CoinSuccess;  // 코인 조건 달성 여부

        public RankResult(GRADE grade, bool timeSuccess, bool coinSuccess)
        {
            Grade = grade;
            TimeSuccess = timeSuccess;
            CoinSuccess = coinSuccess;
        }
    }

    //스테이지 클리어 후 등급 결정 UI
    public void ShowClearUI(RankResult result)
    {
        clearUI.SetActive(true);
        gradeImage.sprite = gradeSprites[(int)result.Grade];
        timeCheckIcon.sprite = result.TimeSuccess ? checkSprite : crossSprite;
        coinCheckIcon.sprite = result.CoinSuccess ? checkSprite : crossSprite;
        gradeAnim.SetTrigger("ShowGrade");
        Time.timeScale = 0f;
    }

    public void GameOverUI()
    {

        gameoverUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void OnEscape()
    {
        if (pauseUI.activeSelf || clearUI.activeSelf || gameoverUI.activeSelf)
            return;
        escapeUI.SetActive(true);
        Time.timeScale = 0f;
    }
    #region 버튼들

    //일시정지 버튼 누르면 시간 멈추고 ui 등장
    public void OnPauseBtn()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }
    //현재 스테이지 이어서
    public void OnResumeBtn()
    {
        pauseUI.SetActive(false);
        escapeUI.SetActive(false);
        Time.timeScale = 1f;
    }
    //현재 스테이지 재시작
    public void OnReplayBtn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //스테이지 선택씬으로 이동
    public void OnExitToStageSelectBtn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        SoundManager.Instance.PlaySound(SoundType.BGM, "Goblins_Den_(Regular)");
    }
    //게임 종료(Esc)
    public void OnExitGameBtn()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        // 실제 빌드된 게임에서는 애플리케이션 종료
        Application.Quit();
#endif
    }
    #endregion

}




