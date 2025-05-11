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

}
