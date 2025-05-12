using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum SoundType
{
    BGM,
    SFX
}

public class SoundManager : Singleton<SoundManager>
{
    /*
    < 씬 별 사운드 >
    1. 메인화면
    1-1. 도전 과제 화면
    2. 스테이지 선택 화면
    2-1. 커스텀 화면
    3. 스테이지 1
    3-1. 스테이지 2
    3-2. 스테이지 3

    < 사운드가 필요한 때 >
    1. 캐릭터 점프
    2. 캐릭터 죽음 = 게임 오버
    3. 오브젝트와 상호작용 (레버나 스위치)
    4. 문 열림
    5. 게임 클리어
    */

    [SerializeField] private AudioMixer mAudioMixer;
    //사운드 타입의 볼륨 조절

    private float mCurrentBGMVolume, mCurrentSFXVolume;
    //현재 배경음악, 효과 사운드 볼륨

    private Dictionary<string, AudioClip> mClipsDictionary;
    //클립 딕셔너리

    [SerializeField] private AudioClip[] mPreloadClips;
    //미리 로드해놓을 클립들 =============================== 필요한가?

    private List<TemporarySoundPlayer> mInstantiatedSounds;

    private void Start()
    {
        mClipsDictionary = new Dictionary<string, AudioClip>();
        //오디오 클립 이름(string), 오디오 클립을 값으로 저장하는 딕셔너리
        foreach(AudioClip clip in mPreloadClips)
        //mPreloadClips : Unity 에디터에서 미리 저장해두는 오디오 클립 배열
        {
            mClipsDictionary.Add(clip.name, clip);
            //clip.name을 키로, clip을 값으로 받음
        }
        mInstantiatedSounds = new List<TemporarySoundPlayer>();
        //
    }
}

public class TemporarySoundPlayer : MonoBehaviour
{

}