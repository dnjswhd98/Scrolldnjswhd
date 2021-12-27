using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource Audios;
    public List<AudioClip> Clips;
    private bool DeadPlay;

    void Start()
    {
        Audios = GetComponent<AudioSource>();

        object[] obj = Resources.LoadAll("Sound/Hotline Miami");

        for (int i = 0; i < obj.Length; ++i)
        {
            Clips.Add(obj[i] as AudioClip);
        }
        DeadPlay = false;
    }

    
    public void SetAudio(int ClipNum)
    {
        Audios.clip = Clips[ClipNum];
        Audios.loop = false;
        Audios.Play();
    }
}
