using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    private AudioSource SoundPlayer;

    private void Awake()
    {
        SoundManager.GetInstance.Initialize();
        SoundPlayer = new AudioSource();
        SoundPlayer.clip = SoundManager.GetInstance.GetAudioClip(0);
    }

    void Start()
    {
        Debug.Log(SoundPlayer.clip.name);
        PlaySound();
    }

    public void PlaySound(bool _Loop = false)
    {
        SoundPlayer.volume = 1.0f;
        SoundPlayer.time = 0;
        SoundPlayer.loop = _Loop;
        SoundPlayer.Play();
    }

    public void StopSound()
    {
        SoundPlayer.Stop();
    }
}
