using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    private static WayPointManager Instance = null;
    private static GameObject Constainer = null;

    public static WayPointManager GetInstance()
    {
        if(Instance == null)
        {
            Constainer = new GameObject("WayPointManager");
            Instance = new WayPointManager();

            Instance = Constainer.AddComponent(typeof(WayPointManager)) as WayPointManager;
        }
        return Instance;
    }
    [Tooltip("NodePrefab")]
    [HideInInspector] public GameObject WayPointList;
    [HideInInspector] public Vector2 PointA;
    [HideInInspector] public Vector2 PointB;

    [HideInInspector] public Vector2 TargetPoint;

    [HideInInspector] public List<GameObject> NodeList = new List<GameObject>();

    private void Awake()
    {
        WayPointList = Resources.Load("Prefabs/Stap_11/WayPointList") as GameObject;
    }

    private void Start()
    {
        for(int i = 0; i < 10; ++i)
        {
            GameObject Obj = Instantiate(WayPointList);

            Obj.transform.position = new Vector3(Random.Range(-20,20), 0.0f, Random.Range(-20,20));
        }
    }
    /* 시간마다 생성하게 하는 방법
    float fTime = 5.0;
    private void Update()
    {
        fTime -= Time.deltaTime;

        if(fTime<0)
        {
            fTime = 5.0f;
            생성할것 작업
        }
    }
    */
}
