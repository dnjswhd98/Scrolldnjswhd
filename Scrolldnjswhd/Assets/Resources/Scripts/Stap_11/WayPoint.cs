using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField]private Vector2 Radius;

    public GameObject WayPointprefab;
    [SerializeField]private GameObject Enemyprefab;
    [SerializeField]private int WayPointCount = 0;
    [SerializeField]private int NodeNum = 0;

    public List<GameObject> WayPointList = new List<GameObject>();

    private void Awake()
    {
        WayPointprefab = Resources.Load("Prefabs/Stap_11/WayPointPrefab") as GameObject;
        Enemyprefab = Resources.Load("Prefabs/Stap_11/Enemy") as GameObject;
    }

    void Start()
    {
        NodeNum = 0;

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
        }
    }

    private void Update()
    {
        //WayPointList[NodeNum]

        ++NodeNum;

        if(NodeNum > (WayPointList.Count - 1))
        {

        }
    }
}
