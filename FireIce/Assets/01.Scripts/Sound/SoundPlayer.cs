using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class SoundPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioSource AudioSourceComp { get { return audioSource; } }


    public void Setting(AudioMixerGroup mixerGroup, AudioClip clip, bool isLoop)
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.outputAudioMixerGroup = mixerGroup;
        audioSource.clip = clip;
        audioSource.loop = isLoop;
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
        yield return new WaitForSeconds(time * 5);

        string typeName = audioSource.outputAudioMixerGroup.ToString();
        SoundManager.Instance.soundPlayerDic[(SOUNDTYPE)Enum.Parse(typeof(SOUNDTYPE), typeName)].Remove(this);

        Destroy(gameObject);
    }
}
