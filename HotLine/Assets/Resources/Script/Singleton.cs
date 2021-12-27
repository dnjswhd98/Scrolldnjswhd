using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton
{
    private static Singleton Instance = null;
    public static Singleton GetInstance
    {
        get
        {
            if (Instance == null)
                Instance = new Singleton();

            return Instance;
        }
    }

    private List<GameObject> EnableList = new List<GameObject>();
    public List<GameObject> GetEnableList
    {
        get
        {
            return EnableList;
        }
    }
    private Stack<GameObject> DisableList = new Stack<GameObject>();
    public Stack<GameObject> GetDisableList
    {
        get
        {
            return DisableList;
        }
    }

    private SoundManager Sound1 = GameObject.Find("Sound1").GetComponent<SoundManager>();
    private SoundManager Sound2 = GameObject.Find("Sound2").GetComponent<SoundManager>();
    private SoundManager Sound3 = GameObject.Find("Sound3").GetComponent<SoundManager>();

    //public enum Weapone
    //{
    //    NONE,
    //    BAT,
    //    CLUB,
    //    KNIFE,
    //    KATANA,
    //    PIPE,
    //    CREWBAR,
    //    M16,
    //    SHOTGUN,
    //    DOUBLEBARREL,
    //    UZI
    //};

    static public List<GameObject> EnemyList = new List<GameObject>();

    public void SetEnemyList()
    {
        for(int i = 0; i <GameManager.ESpawnList.Count; ++i)
        {
            EnemyList.Add(GameObject.Find("Enemy" + i + "(Clone)"));
        }
        for (int i = 0; i < GameManager.DSpawnList.Count; ++i)
        {
            EnemyList.Add(GameObject.Find("Dog" + i + "(Clone)"));
        }

    }

    public void PlayingSound(int ClipNum)
    {
        if(!Sound1.Audios.isPlaying)
        {
            Sound1.SetAudio(ClipNum);
        }
        else
        {
            if(!Sound2.Audios.isPlaying)
                Sound2.SetAudio(ClipNum);
            else
                Sound3.SetAudio(ClipNum);
        }
    }
}
