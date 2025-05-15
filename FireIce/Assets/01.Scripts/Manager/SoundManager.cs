using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioMixer audioMixer;
    //오디오 믹서로 볼륨 조절

    [SerializeField] private List<AudioClip> audioClipList;
    //사용할 오디오 클립 보관

    [HideInInspector]public Dictionary<SOUNDTYPE, List<SoundPlayer>> soundPlayerDic;
    //재생 중인 SoundPlayer을 보관

    public AudioMixer AudioMixer { get { return audioMixer; } }
    //외부에서 오디오 믹서 접근 허용

    protected override void Awake()
    {
        base.Awake();
        soundPlayerDic = new Dictionary<SOUNDTYPE, List<SoundPlayer>>();
        //딕셔너리 초기화
        SoundManager.Instance.PlaySound(SOUNDTYPE.BGM, "RealCubyTwoMainTheme");
    }

    public void SetVolume(SOUNDTYPE type, float volume) //볼륨 조절
    {
        audioMixer.SetFloat(type.ToString(), Mathf.Log10(volume) * 20);
    }

    public void PlaySound(SOUNDTYPE type, string name, bool isLoop = true) //사운드 재생
    {
        if(type == SOUNDTYPE.SFX)
        {
            isLoop = false;
        }

        if (type == SOUNDTYPE.BGM && soundPlayerDic.ContainsKey(type) && soundPlayerDic[type].Count >= 1)
        {
            Debug.Log("노래 재생 중");
            return;
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

    public void StopSound(SOUNDTYPE type)
    {
        if (soundPlayerDic.ContainsKey(type))
        {
            foreach (SoundPlayer sp in soundPlayerDic[type])
            {
                sp.AudioSourceComp.Stop();
                Destroy(sp.gameObject);
            }
            soundPlayerDic[type].Clear();
        }
    }
}