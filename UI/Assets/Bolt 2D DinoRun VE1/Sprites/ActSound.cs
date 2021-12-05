using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActSound : MonoBehaviour
{
    private AudioSource Audios;
    [SerializeField]private List<AudioClip> Clips;
    private bool DeadPlay;

    void Start()
    {
        Audios = GetComponent<AudioSource>();

        object[] obj = Resources.LoadAll("Audio");

        for (int i = 0; i < obj.Length; ++i)
        {
            Clips.Add(obj[i] as AudioClip);
        }
        DeadPlay = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !DinoCon.dead)
        {
            Audios.clip = Clips[2];
            Audios.Play();
        }
        if(DinoCon.dead && !DeadPlay)
        {
            Audios.clip = Clips[1];
            Audios.Play();
            DeadPlay = true;
        }
    }

    public void RestartButtonDown()
    {
        Audios.clip = Clips[0];
        Audios.Play();
        DeadPlay = false;
    }
}
