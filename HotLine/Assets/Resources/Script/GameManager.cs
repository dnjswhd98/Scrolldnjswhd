using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private GameObject EnemyPrefab;
    static public List<GameObject> ESpawnList;
    [SerializeField] private List<GameObject> Elist;

    private void Awake()
    {
        PlayerPrefab = Resources.Load("Prefap/Jaket") as GameObject;
        EnemyPrefab = Resources.Load("Prefap/EnemyMafiaBat") as GameObject;
    }

    private void Start()
    {
        ESpawnList = new List<GameObject>();
        for (int i = 0; i < 7; ++i)
            ESpawnList.Add(GameObject.Find("EnemySpawn" + i));
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
            Instantiate(EnemyPrefab);
        }
        Singleton.GetInstance.SetEnemyList();
    }
}
