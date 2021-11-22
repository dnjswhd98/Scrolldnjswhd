using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField]private Vector2 Radius;

    private Vector2 PointA;
    private Vector2 PointB;

    public GameObject WayPointprefab;
    [SerializeField]private int WayPointCount = 0;

    public List<GameObject> WayPointList = new List<GameObject>();

    private void Awake()
    {
        WayPointprefab = Resources.Load("Prefabs/Stap_11/WayPointPrefab") as GameObject;
    }

    void Start()
    {
        PointA = new Vector2(transform.position.x - Radius.x, transform.position.z + Radius.y);
        PointB = new Vector2(transform.position.x + Radius.x, transform.position.z - Radius.y);

        for(int i = 0;i<WayPointCount;++i)
        {
            GameObject Obj = Instantiate(WayPointprefab);

            Obj.AddComponent<Rigidbody>();
            Obj.AddComponent<SphereCollider>();

            Obj.name = "Way" + i;
            Obj.transform.position = new Vector3( Random.Range(PointA.x,PointB.x), 5.0f, Random.Range(PointA.y,PointB.y));
            WayPointList.Add(Obj);
        }
    }

   
}
