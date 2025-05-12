using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnController : MonoBehaviour
{

    public void OnStartBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExitBtn()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        // 실제 빌드된 게임에서는 애플리케이션 종료
        Application.Quit();
#endif
    }
    public void OnStage1()
    {
        SceneManager.LoadScene(2);
    }
    public void OnStage2()
    {
        SceneManager.LoadScene(3);
    }
    public void OnStage3()
    {
        SceneManager.LoadScene(4);
    }
    public void OnStage4()
    {
        SceneManager.LoadScene(5);
    }
    public void OnStage5()
    {
        SceneManager.LoadScene(6);
    }
    public void OnCostume()
    {
        SceneManager.LoadScene(7);
    }
    public void StageSelectToTitle()
    {
        SceneManager.LoadScene(0);
    }
    public void CustumeToStageSelect()
    {
        SceneManager.LoadScene(1);
    }
}

