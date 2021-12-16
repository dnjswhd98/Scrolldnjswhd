using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private GameObject DogPrefab;
    static public List<GameObject> ESpawnList;
    static public List<GameObject> DSpawnList;
    [SerializeField] private List<GameObject> Elist;

    private void Awake()
    {
        PlayerPrefab = Resources.Load("Prefap/Jaket") as GameObject;
        EnemyPrefab = Resources.Load("Prefap/EnemyMafiaBat") as GameObject;
        DogPrefab = Resources.Load("Prefap/Dog") as GameObject;
    }

    private void Start()
    {
        ESpawnList = new List<GameObject>();
        DSpawnList = new List<GameObject>();

        for (int i = 0; i < 9; ++i)
            ESpawnList.Add(GameObject.Find("EnemySpawn" + i));

        for (int i = 0; i < 2; ++i)
            DSpawnList.Add(GameObject.Find("DogSpawn" + i));
        
        SpawnObject();
        Elist = Singleton.EnemyList;
    }

    private void SpawnObject()
    {
        PlayerPrefab.transform.position = GameObject.Find("PlayerSpawn").transform.position;
        Instantiate(PlayerPrefab);

        for (int i = 0; i < ESpawnList.Count; ++i)
        {
            EnemyPrefab.transform.position = GameObject.Find("EnemySpawn" + i).transform.position;
            EnemyPrefab.name = ("Enemy" + i);
            if (i < 2)
                EnemyPrefab.transform.Find("MafiaTop").GetComponent<MafiaMoveTest>().WeaponNum = 1;
            else if (i >= 2 && i < 4)
                EnemyPrefab.transform.Find("MafiaTop").GetComponent<MafiaMoveTest>().WeaponNum = 2;
            else if (i == 4)
                EnemyPrefab.transform.Find("MafiaTop").GetComponent<MafiaMoveTest>().WeaponNum = 3;
            else if (i >= 5 && i < 7)
                EnemyPrefab.transform.Find("MafiaTop").GetComponent<MafiaMoveTest>().WeaponNum = 7;
            else
                EnemyPrefab.transform.Find("MafiaTop").GetComponent<MafiaMoveTest>().WeaponNum = 9;

            //EnemyPrefab.transform.Find("MafiaTop").GetComponent<MafiaMoveTest>().SetWeaponNum(7);
            Instantiate(EnemyPrefab);
        }

        for (int i = 0; i < DSpawnList.Count; ++i)
        {
            DogPrefab.transform.position = GameObject.Find("DogSpawn" + i).transform.position;
            DogPrefab.name = ("Dog" + i);
            Instantiate(DogPrefab);
        }

        Singleton.GetInstance.SetEnemyList();
    }
}
