using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class SoundPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    private SoundType soundType;

    public AudioSource AudioSource => audioSource;
    public bool IsPlaying => audioSource != null && audioSource.isPlaying;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void Setting(AudioMixerGroup mixerGroup, AudioClip clip, bool isLoop, SoundType type)
    {
        audioSource.outputAudioMixerGroup = mixerGroup;
        audioSource.clip = clip;
        audioSource.loop = isLoop;
        soundType = type;
    }

    public void Play()
    {
        audioSource.Play();
        if (!audioSource.loop)
        {
            StartCoroutine(DestroyWhenEndSound(audioSource.clip.length));
        }
    }

    IEnumerator DestroyWhenEndSound(float time)
    {
        yield return new WaitForSeconds(time);

        audioSource.Stop();
        audioSource.clip = null;

        if (SoundManager.Instance.soundPlayerDic.ContainsKey(soundType))
        {
            SoundManager.Instance.soundPlayerDic[soundType].Remove(this);
        }

        Destroy(gameObject);
        //SoundManager.Instance.soundPlayerDic[soundType].Remove(this);

        //string typeName = audioSource.outputAudioMixerGroup.ToString();
        //SoundManager.Instance.soundPlayerDic[(SoundType)Enum.Parse(typeof(SoundType), typeName)].Remove(this);
    }
}
