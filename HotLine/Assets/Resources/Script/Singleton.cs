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
}
