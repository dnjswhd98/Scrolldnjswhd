using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject PlayerPrefab;
    private GameObject EnemyPrefab;
    private GameObject DogPrefab;
    private GameObject FloorArow;
    private GameObject StageUi;

    static public List<GameObject> ESpawnList;
    static public List<GameObject> DSpawnList;
    [SerializeField] private List<GameObject> Elist;

    private bool Intro;
    private bool Firstfloor;
    private bool Secondfloor;

    private void Awake()
    {
        PlayerPrefab = Resources.Load("Prefap/Jaket") as GameObject;
        EnemyPrefab = Resources.Load("Prefap/EnemyMafiaBat") as GameObject;
        DogPrefab = Resources.Load("Prefap/Dog") as GameObject;
        StageUi = GameObject.Find("StageUi");
        Intro = false;
        Firstfloor = true;
        Secondfloor = false;

    }

    private void Start()
    {
        if(Intro)
        {
            StageUi.active = false;
        }
        else if (Firstfloor)
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
    }

    private void Update()
    {
        if (Firstfloor)
        {
            if (Singleton.EnemyList.Count == 0)
            {

            }
        }
        if(GameObject.FindWithTag("player").GetComponent<JaketMoving>().Dead)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                ReStart();
            }
        }
    }

    private void SpawnObject()
    {
        if (Firstfloor)
        {
            PlayerPrefab.transform.position = GameObject.Find("PlayerSpawn").transform.position;
            Instantiate(PlayerPrefab);

            for (int i = 0; i < ESpawnList.Count; ++i)
            {
                EnemyPrefab.transform.position = GameObject.Find("EnemySpawn" + i).transform.position;
                EnemyPrefab.transform.rotation = GameObject.Find("EnemySpawn" + i).transform.rotation;
                if (i < 2)
                {
                    EnemyPrefab.transform.Find("MafiaTop").GetComponent<MafiaMoveTest>().WeaponNum = 1;
                    if (i == 1)
                        EnemyPrefab.GetComponent<MafiaMovement>().MovePoint = GameObject.Find("Enemy1Point");
                }
                else if (i >= 2 && i < 4)
                {
                    EnemyPrefab.transform.Find("MafiaTop").GetComponent<MafiaMoveTest>().WeaponNum = 2;
                }
                else if (i == 4)
                    EnemyPrefab.transform.Find("MafiaTop").GetComponent<MafiaMoveTest>().WeaponNum = 3;
                else if (i >= 5 && i < 7)
                {
                    EnemyPrefab.transform.Find("MafiaTop").GetComponent<MafiaMoveTest>().WeaponNum = 7;
                }
                else
                {
                    EnemyPrefab.transform.Find("MafiaTop").GetComponent<MafiaMoveTest>().WeaponNum = 9;
                    if (i == 7)
                        EnemyPrefab.GetComponent<MafiaMovement>().MovePoint = GameObject.Find("Enemy2Point");
                    if (i == 8)
                        EnemyPrefab.GetComponent<MafiaMovement>().MovePoint = GameObject.Find("Enemy8Point");
                }
                EnemyPrefab.name = ("Enemy" + i);
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

    private void ReStart()
    {
        for (int i = 0; i < Singleton.EnemyList.Count; ++i)
        {
           Singleton.EnemyList.RemoveAt(i);
        }

        Destroy(GameObject.FindWithTag("player").gameObject);
        Destroy(GameObject.FindWithTag("Enemy").gameObject);
        Destroy(GameObject.FindWithTag("Dog").gameObject);
        Destroy(GameObject.FindWithTag("Item").gameObject);

        Start();
    }
}
