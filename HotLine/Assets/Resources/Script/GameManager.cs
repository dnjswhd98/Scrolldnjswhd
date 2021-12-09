using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private GameObject EnemyPrefab;

    private void Awake()
    {
        PlayerPrefab = Resources.Load("Prefap/Jaket") as GameObject;
        EnemyPrefab = Resources.Load("Prefap/EnemyMafiaBat") as GameObject;
    }

    private void Start()
    {
        SpawnObject();
    }

    private void SpawnObject()
    {
        PlayerPrefab.transform.position = GameObject.Find("PlayerSpawn").transform.position;
        EnemyPrefab.transform.position = GameObject.Find("EnemySpawn").transform.position;
        Instantiate(PlayerPrefab);
        Instantiate(EnemyPrefab);
    }
}
