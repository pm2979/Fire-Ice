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
        SoundManager.Instance.PlaySound(SOUNDTYPE.BGM, "RealCubyTwoMainTheme");
    }

    public void OnAchievement()
    {
        SceneManager.LoadScene(8);
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
        SoundManager.Instance.StopSound(SOUNDTYPE.BGM);
        SoundManager.Instance.PlaySound(SOUNDTYPE.BGM, "RealCubyTwoMainTheme");
    }
    public void OnStage2()
    {
        SceneManager.LoadScene(3);
        SoundManager.Instance.StopSound(SOUNDTYPE.BGM);
        SoundManager.Instance.PlaySound(SOUNDTYPE.BGM, "RealCubyTwoMainTheme");
    }
    public void OnStage3()
    {
        SceneManager.LoadScene(4);
        SoundManager.Instance.StopSound(SOUNDTYPE.BGM);
        SoundManager.Instance.PlaySound(SOUNDTYPE.BGM, "RealCubyTwoMainTheme");
    }
    public void OnStage4()
    {
        SceneManager.LoadScene(5);
        SoundManager.Instance.StopSound(SOUNDTYPE.BGM);
        SoundManager.Instance.PlaySound(SOUNDTYPE.BGM, "RealCubyTwoMainTheme");
    }
    public void OnStage5()
    {
        SceneManager.LoadScene(6);
        SoundManager.Instance.StopSound(SOUNDTYPE.BGM);
        SoundManager.Instance.PlaySound(SOUNDTYPE.BGM, "RealCubyTwoMainTheme");
    }
    public void OnCostume()
    {
        SceneManager.LoadScene(7);
        SoundManager.Instance.PlaySound(SOUNDTYPE.BGM, "RealCubyTwoMainTheme");
    }
    public void StageSelectToTitle()
    {
        SceneManager.LoadScene(0);
        SoundManager.Instance.PlaySound(SOUNDTYPE.BGM, "RealCubyTwoMainTheme");
    }
    public void CustumeToStageSelect()
    {
        SceneManager.LoadScene(1);
        SoundManager.Instance.PlaySound(SOUNDTYPE.BGM, "RealCubyTwoMainTheme");
    }
}

