using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MafiaRay : MonoBehaviour
{
    private bool Walking;
    private bool FindPlayer;

    public float Radius;
    [Range(0,360)]public float Angle;

    private LayerMask TargetMask;
    [SerializeField]private LayerMask OnstacleMask;
    [SerializeField]private Collider2D InTargets;

    private Vector2 Direction;

    private float LineAngle = 0;

    GameObject Targeet;

    Mesh ViewMesh;

    public struct ViewCastInfo
    {
        public bool Hit;
        public Vector3 Point;
        public float Distance;
        public float Angle;

        public ViewCastInfo(bool _Hit, Vector3 _Point, float _Distance, float _Angle)
        {
            Hit = _Hit;
            Point = _Point;
            Distance = _Distance;
            Angle = _Angle;
        }
    }

    void Start()
    {
        Targeet = Resources.Load("Prefap/Jaket") as GameObject;
        ViewMesh = new Mesh();
        ViewMesh.name = "View Mesh";

        Direction = transform.right;

        OnstacleMask = LayerMask.GetMask("Wall");
        TargetMask = LayerMask.GetMask("Player");

        Radius = 5.0f;
        Angle = 95.0f;
        LineAngle = 3;
    }

    void Update()
    {

        //for (int i = 0; i < 10; ++i)
        //{
        //    float Tangle;
        //    if (i < 5)
        //    {
        //        Tangle = Angle + (LineAngle * i);
        //        Angle = Tangle;
        //        if (Physics2D.Raycast(transform.position, GetDistancee(), Radius, OnstacleMask))
        //            Debug.Log(GetDistancee());
        //    }
        //    else
        //    {
        //        Tangle = -(Angle + (LineAngle * i));
        //        Angle = Tangle;
        //        if (Physics2D.Raycast(transform.position, GetDistancee(), Radius, OnstacleMask))
        //            Debug.Log(GetDistancee());
        //    }
        //}

        InTargets = Physics2D.OverlapCircle(transform.position, Radius, TargetMask);
       

       Transform Target = Targeet.transform;
    
       Vector2 TargetDirection = (Target.position - transform.position).normalized;
    
       if (Vector2.Angle(transform.up, TargetDirection) < Angle / 2)
       {
           float TargetDistance = Vector2.Distance(transform.position, Target.position);
    
           if (!Physics.Raycast(transform.position, TargetDirection, TargetDistance, OnstacleMask))
               Debug.Log("find");
    
       }
    }

    private void LateUpdate()
    {
        int LineCount = Mathf.RoundToInt(Angle / LineAngle);

        float AngleSize = Angle / LineCount;

        List<Vector2> ViewPointList = new List<Vector2>();

        for (int i = 0; i < LineCount - 1; ++i)
        {
            float ViewAngle = transform.eulerAngles.y - (Angle / 2) + AngleSize * i;

            ViewCastInfo tViewCast = ViewCast(ViewAngle);

            ViewPointList.Add(tViewCast.Point);
        }


        int VertexCount = ViewPointList.Count + 1;

        Vector3[] VertexList = new Vector3[VertexCount];
        VertexList[0] = Vector2.zero;

        int[] Teiangle = new int[(VertexCount - 2) * 3];

        for (int i = 0; i < VertexCount - 1; ++i)
        {
            VertexList[i + 1] = transform.InverseTransformPoint(ViewPointList[i]);

            if (i < VertexCount - 2)
            {
                Teiangle[i * 3] = 0;
                Teiangle[i * 3 + 1] = i + 1;
                Teiangle[i * 3 + 2] = i + 2;
            }
        }

        ViewMesh.Clear();
        ViewMesh.vertices = VertexList;
        ViewMesh.triangles = Teiangle;

        ViewMesh.RecalculateNormals();
    }

    public Vector2 LocalViewAngle(float _Angle)
    {
        _Angle += transform.eulerAngles.z;
        return new Vector2(Mathf.Sin(_Angle * Mathf.Deg2Rad), Mathf.Cos(_Angle * Mathf.Deg2Rad));
    }

    public Vector2 DirectionAngle(float _Angle)
    {
        return new Vector2(Mathf.Sin(_Angle * Mathf.Deg2Rad), Mathf.Cos(_Angle * Mathf.Deg2Rad));
    }

    public ViewCastInfo ViewCast(float _Angle)
    {
        Vector3 Direction = DirectionAngle(_Angle);

        RaycastHit Hit;

        if (Physics.Raycast(transform.position, Direction, out Hit, Radius, TargetMask))
        {
            return new ViewCastInfo(true, Hit.point, Hit.distance, _Angle);
        }

        //Distance

        return new ViewCastInfo
            (
            false,
            transform.position + Direction * Radius,
            Radius,
            _Angle);
    }

    private Vector2 GetDistancee()
    {
        Vector3 direction = transform.right;

        var quaternion = Quaternion.Euler(0, 0, Angle);
        Vector3 newDirection = quaternion * direction;

        return newDirection; 
    }
}
