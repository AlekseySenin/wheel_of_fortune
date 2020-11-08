using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private List<Sound> sounds;
    [SerializeField] private AudioSource audioSource;

    private static Action <SoundType> OnPlaySound;

    private void Awake()
    {
        OnPlaySound += Play;
    }

    private void OnDestroy()
    {
        OnPlaySound -= Play;

    }

    public static void PlaySound(SoundType soundType)
    {
        OnPlaySound?.Invoke(soundType);
    }

    private void Play(SoundType soundType)
    {
        AudioClip audioClip = sounds.Find(x => x.soundType == soundType).audioClip;
        audioSource.PlayOneShot(audioClip);
    }

}

[System.Serializable]

public enum SoundType
{
    drummClick, buttonClick, coinWin  
}
[System.Serializable]
public class Sound
{
    public SoundType soundType;
    public AudioClip audioClip;
}
