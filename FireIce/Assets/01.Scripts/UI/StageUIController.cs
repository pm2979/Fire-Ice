using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class StageUIController : MonoBehaviour
{
    //������������ �Ͻ�����, Ŭ���� �帧�� ui�� ����մϴ�.

    [Header("UI �г�")]
    public GameObject pauseUI;
    public GameObject clearUI;
    public GameObject gameoverUI;
    public GameObject escapeUI;

    [Header("���� ��� �ִϸ��̼�")]
    [SerializeField] private Animator gradeAnim;

    [Header("��� ǥ�ÿ� UI")]
    [SerializeField] private Image gradeImage;
    [SerializeField] private Sprite[] gradeSprites;// A,B,C 

    [Header("���� üũ ������")]
    [SerializeField] private Image timeCheckIcon;
    [SerializeField] private Image coinCheckIcon;
    [SerializeField] private Sprite checkSprite;         
    [SerializeField] private Sprite crossSprite;


    public struct RankResult
    {
        public GRADE Grade;       // A, B, C
        public bool TimeSuccess;  // �ð� ���� �޼� ����
        public bool CoinSuccess;  // ���� ���� �޼� ����

        public RankResult(GRADE grade, bool timeSuccess, bool coinSuccess)
        {
            Grade = grade;
            TimeSuccess = timeSuccess;
            CoinSuccess = coinSuccess;
        }
    }

    //�������� Ŭ���� �� ��� ���� UI
    public void ShowClearUI(RankResult result)
    {
        clearUI.SetActive(true);
        StartCoroutine(PlayMatchSoundRepeated("match", 3, 0.1f));
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
    #region ��ư��

    //�Ͻ����� ��ư ������ �ð� ���߰� ui ����
    public void OnPauseBtn()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }
    //���� �������� �̾
    public void OnResumeBtn()
    {
        pauseUI.SetActive(false);
        escapeUI.SetActive(false);
        Time.timeScale = 1f;
    }
    //���� �������� �����
    public void OnReplayBtn()
    {
        Time.timeScale = 1f;
        BaseController[] controllers = FindObjectsOfType<BaseController>();

        // �ϳ��� ���鼭 �ش� ������Ʈ�� ���� ���ӿ�����Ʈ�� �ı�
        foreach (BaseController ctrl in controllers)
        {
            Destroy(ctrl.gameObject);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //�������� ���þ����� �̵�
    public void OnExitToStageSelectBtn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    //Ÿ��Ʋ�� ���ư���
    public void OnGoToTitle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    //���� ����(Esc)
    public void OnExitGameBtn()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        // ���� ����� ���ӿ����� ���ø����̼� ����
        Application.Quit();
#endif
    }
    #endregion

    private IEnumerator PlayMatchSoundRepeated(string soundName, int count, float delay)
    {
        for(int i = 0; i < count; i++)
        {
            SoundManager.Instance.PlaySound(SOUNDTYPE.SFX, soundName);
            yield return new WaitForSecondsRealtime(delay);
        }
    }
}




