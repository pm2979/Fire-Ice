using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageUIController : MonoBehaviour
{
    //스테이지에서 일시정지, 클리어 흐름과 ui를 담당합니다.

    [Header("UI 패널")]
    public GameObject pauseUI;
    public GameObject clearUI;

    //체크 혹은 x 이미지 , 등급 이미지, 나가기 버튼

    

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
        Time.timeScale = 1f;
    }
    //현재 스테이지 재시작
    public void OnReplayBtn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //스테이지 선택씬으로 이동
    public void OnExitToStageSelect()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    #endregion


}
