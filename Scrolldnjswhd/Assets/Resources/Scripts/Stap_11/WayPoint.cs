using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField]private Vector2 Radius;

    public GameObject WayPointprefab;
    [SerializeField]private GameObject Enemyprefab;
    [SerializeField]private int WayPointCount = 0;

    public List<GameObject> WayPointList = new List<GameObject>();

    [SerializeField]private int Direction;
    [SerializeField]private float fTime = 1.0f;

    private void Awake()
    {
        WayPointprefab = Resources.Load("Prefabs/Stap_11/WayPointPrefab") as GameObject;
    }

    void Start()
    {
        StartCoroutine("EnemyCreate");
        WayPointManager.GetInstance().PointA = new Vector2(transform.position.x - Radius.x, transform.position.z + Radius.y);
        WayPointManager.GetInstance().PointB = new Vector2(transform.position.x + Radius.x, transform.position.z - Radius.y);

        for(int i = 0;i<WayPointCount;++i)
        {
            GameObject Obj = Instantiate(WayPointprefab);

            Obj.AddComponent<Rigidbody>();
            Obj.AddComponent<BoxCollider>();

            Obj.transform.parent = transform;

            Obj.transform.position = new Vector3(
                Random.Range(WayPointManager.GetInstance().PointA.x, WayPointManager.GetInstance().PointB.x),
                5.0f,
                Random.Range(WayPointManager.GetInstance().PointA.y, WayPointManager.GetInstance().PointB.y));
            WayPointList.Add(Obj);

            int NodeNumber = WayPointManager.GetInstance().NodeNumber;

            WayPointManager.GetInstance().TargetPoint = WayPointList[NodeNumber].transform.position;
        }
    }

    IEnumerator EnemyCreate()
    {
        yield return new WaitForSeconds(fTime);
        GameObject Enemy = Instantiate(WayPointManager.GetInstance().EnemyPrefab);
        Enemy.transform.position = WayPointManager.GetInstance().WayPointList.transform.position;
    }
}
