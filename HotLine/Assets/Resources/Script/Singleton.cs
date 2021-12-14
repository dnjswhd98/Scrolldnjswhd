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

    public enum Weapone
    {
        NONE,
        BAT,
        CLUB,
        KNIFE,
        KATANA,
        PIPE,
        CREWBAR,
        M16,
        SHOTGUN,
        DOUBLEBARREL,
        UZI
    };

    private bool PlayerFind = false;

    static public List<GameObject> EnemyList = new List<GameObject>();

    public void SetEnemyList()
    {
        for(int i = 0; i <GameManager.ESpawnList.Count; ++i)
        {
            EnemyList.Add(GameObject.Find("Enemy" + i + "(Clone)"));
        }
    }

    public void SetEnemyHit(GameObject _obj, bool _hit)
    {
        //_obj.GetComponent<MafiaMoveTest>().Hit = _hit;
    }
}
