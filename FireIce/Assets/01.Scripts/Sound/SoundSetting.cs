using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        float saveBGM = PlayerPrefs.GetFloat("BGMVolume", 1f); //����� BGM �� �ҷ�����(������ 100%)
        float saveSFX = PlayerPrefs.GetFloat("SFXVolume", 1f);

        bgmSlider.value = saveBGM;
        sfxSlider.value = saveSFX;
        
        bgmSlider.onValueChanged.AddListener(OnBGMChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXChanged);
        //Slider ���� �� ȣ��

        SoundManager.Instance.SetVolume(SOUNDTYPE.BGM, saveBGM); //�ҷ��� ������ ����
        SoundManager.Instance.SetVolume(SOUNDTYPE.SFX, saveSFX);
    }

    private void OnBGMChanged(float value) //BGM ���� �� ȣ��
    {
        SoundManager.Instance.SetVolume(SOUNDTYPE.BGM, value);
        PlayerPrefs.SetFloat("BGMVolume", value); //BGM ������ ����
        PlayerPrefs.Save();
    }

    private void OnSFXChanged(float value) //SFX ���� �� ȣ��
    {
        SoundManager.Instance.SetVolume(SOUNDTYPE.SFX, value);
        PlayerPrefs.SetFloat("SFXVolume", value); //SFX ������ ����
        PlayerPrefs.Save();
    }
}
