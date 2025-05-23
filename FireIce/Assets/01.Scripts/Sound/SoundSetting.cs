using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        float saveBGM = PlayerPrefs.GetFloat("BGMVolume", 1f); //저장된 BGM 값 불러오기(없으면 100%)
        float saveSFX = PlayerPrefs.GetFloat("SFXVolume", 1f);

        bgmSlider.value = saveBGM;
        sfxSlider.value = saveSFX;
        
        bgmSlider.onValueChanged.AddListener(OnBGMChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXChanged);
        //Slider 변경 시 호출

        SoundManager.Instance.SetVolume(SOUNDTYPE.BGM, saveBGM); //불러온 값으로 적용
        SoundManager.Instance.SetVolume(SOUNDTYPE.SFX, saveSFX);
    }

    private void OnBGMChanged(float value) //BGM 변경 시 호출
    {
        SoundManager.Instance.SetVolume(SOUNDTYPE.BGM, value);
        PlayerPrefs.SetFloat("BGMVolume", value); //BGM 볼륨값 저장
        PlayerPrefs.Save();
    }

    private void OnSFXChanged(float value) //SFX 변경 시 호출
    {
        SoundManager.Instance.SetVolume(SOUNDTYPE.SFX, value);
        PlayerPrefs.SetFloat("SFXVolume", value); //SFX 볼륨값 저장
        PlayerPrefs.Save();
    }
}
