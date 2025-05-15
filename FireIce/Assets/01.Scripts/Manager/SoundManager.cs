using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioMixer audioMixer;
    //����� �ͼ��� ���� ����

    [SerializeField] private List<AudioClip> audioClipList;
    //����� ����� Ŭ�� ����

    [HideInInspector]public Dictionary<SOUNDTYPE, List<SoundPlayer>> soundPlayerDic;
    //��� ���� SoundPlayer�� ����

    public AudioMixer AudioMixer { get { return audioMixer; } }
    //�ܺο��� ����� �ͼ� ���� ���

    protected override void Awake()
    {
        base.Awake();
        soundPlayerDic = new Dictionary<SOUNDTYPE, List<SoundPlayer>>();
        //��ųʸ� �ʱ�ȭ
        SoundManager.Instance.PlaySound(SOUNDTYPE.BGM, "RealCubyTwoMainTheme");
    }

    public void SetVolume(SOUNDTYPE type, float volume) //���� ����
    {
        audioMixer.SetFloat(type.ToString(), Mathf.Log10(volume) * 20);
    }

    public void PlaySound(SOUNDTYPE type, string name, bool isLoop = true) //���� ���
    {
        if(type == SOUNDTYPE.SFX)
        {
            isLoop = false;
        }

        if (type == SOUNDTYPE.BGM && soundPlayerDic.ContainsKey(type) && soundPlayerDic[type].Count >= 1)
        {
            Debug.Log("�뷡 ��� ��");
            return;
        }

        GameObject go = new GameObject();
        go.transform.parent = transform;
        SoundPlayer sp = go.AddComponent<SoundPlayer>();
        AudioMixerGroup mixerGroup = audioMixer.FindMatchingGroups(type.ToString())[0];
        //AduioMixer���� Ÿ�԰� �´� �ͼ��׷� ã��
        AudioClip clip = audioClipList.Find( x => x.name == name );
        //name���� ����� �˻�

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