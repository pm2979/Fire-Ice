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
    [SerializeField] private AudioMixer audioMixer;
    //오디오 믹서로 볼륨 조절

    [SerializeField] private List<AudioClip> audioClipList;
    //사용할 오디오 클립 보관

    [HideInInspector]public Dictionary<SoundType, List<SoundPlayer>> soundPlayerDic;
    //재생 중인 SoundPlayer을 보관

    public AudioMixer AudioMixer { get { return audioMixer; } }
    //외부에서 오디오 믹서 접근 허용

    protected override void Awake()
    {
        base.Awake();
        soundPlayerDic = new Dictionary<SoundType, List<SoundPlayer>>();
        //딕셔너리 초기화
        SoundManager.Instance.PlaySound(SoundType.BGM, "Goblins_Den_(Regular)");
    }

    public void SetVolume(SoundType type, float volume) //볼륨 조절
    {
        audioMixer.SetFloat(type.ToString(), Mathf.Log10(volume) * 20);
    }

    public void PlaySound(SoundType type, string name, bool isLoop = false) //사운드 재생
    {
        if (type == SoundType.BGM && soundPlayerDic.ContainsKey(type) && soundPlayerDic[type].Count >= 1)
        {
            Debug.Log("노래 재생 중");
            if (soundPlayerDic[type][0].AudioSourceComp.clip.name == name)
            {
                Debug.Log("똑같은 BGM");
                return; //BGM을 다시 요청했을 때 해당 곡으로 바뀌도록 수정
            }

            foreach (var player in soundPlayerDic[type])
            {
                player.AudioSourceComp.Stop();
                Destroy(player.gameObject);
            }
            soundPlayerDic[type].Clear();
        }

        GameObject go = new GameObject();
        go.transform.parent = transform;
        SoundPlayer sp = go.AddComponent<SoundPlayer>();
        AudioMixerGroup mixerGroup = audioMixer.FindMatchingGroups(type.ToString())[0];
        //AduioMixer에서 타입과 맞는 믹서그룹 찾음
        AudioClip clip = audioClipList.Find( x => x.name == name );
        //name으로 오디오 검색

        sp.Setting(mixerGroup, clip, isLoop);
        sp.Play();

        if (soundPlayerDic.ContainsKey(type))
        {
            soundPlayerDic[type].Add(sp);
        }
        else
        {
            soundPlayerDic.Add(type, new List<SoundPlayer> { sp });
        }
    }
}

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
