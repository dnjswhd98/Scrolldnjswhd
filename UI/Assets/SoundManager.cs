using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    static private SoundManager Inctance;
    static public SoundManager GetInstance
    {
        get
        {
            if (Inctance == null)
                Inctance = new SoundManager();

            return Inctance;
        }
    }

    public List<AudioClip> Soundlist = new List<AudioClip>();
    //private AudioSource AudioPlayer = null;

    public void Initialize()
    {
        object[] obj = Resources.LoadAll("Sound");

        for(int i = 0;i<obj.Length;++i)
        {
            Soundlist.Add(obj[i] as AudioClip);
        }
    }

    public AudioClip GetAudioClip(int _Index)
    {
        if (_Index >= Soundlist.Count)
        {
            Debug.Log("재생 가능한 사운드가 없습니다. Index : " + _Index + "최대 Index : " + (Soundlist.Count - 1));
        }
        AudioClip Source = Soundlist[_Index];//new AudioSource();

        //Source.clip = Soundlist[_Index];

        return Source;
    }
    /*
    public void PlayerSound(int _Index, bool _Loop = false)
    {
        if (_Index >= Soundlist.Count)
        {
            Debug.Log("재생 가능한 사운드가 없습니다. Index : " + _Index + "최대 Index : " + (Soundlist.Count - 1));
            return;
        }
    }
    
    public void PlayerSound(string _Name, bool _Loop = false)
    {

    }
    */
}
