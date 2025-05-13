using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        bgmSlider.value = 1f; //기본 볼륨 100%
        sfxSlider.value = 1f;

        bgmSlider.onValueChanged.AddListener(OnBGMChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXChanged);
        //Slider 변경 시 호출
    }

    private void OnBGMChanged(float value) //BGM 변경 시 호출
    {
        SoundManager.Instance.SetVolume(SoundType.BGM, value);
    }

    private void OnSFXChanged(float value) //SFX 변경 시 호출
    {
        SoundManager.Instance.SetVolume(SoundType.SFX, value);
    }
}
