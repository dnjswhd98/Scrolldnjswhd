using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewAngle : MonoBehaviour
{
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

    [Tooltip("�þ� �ִ� �Ÿ�")]
    public float Radius;
    [Tooltip("�þ� �ִ� ����")]
    [Range(0, 360)] public float Angle;

    [Tooltip("TargetLayerMask")]
    [SerializeField] private LayerMask TargetMask;
    [Tooltip("ObstacleLayerMask")]
    [SerializeField] private LayerMask OnstacleMask;

    [Tooltip("TargetList")]
    //[HideInInspector] //inspectorview���� ����
    public List<Transform> TargetList = new List<Transform>();

    //�þ߰��� Line ����
    private int LineAngle = 0;

    Mesh ViewMesh;
    public MeshFilter ViewMeshFilter;

    private void Start()
    {
        ViewMesh = new Mesh();
        ViewMesh.name = "View Mesh";
        ViewMeshFilter.mesh = ViewMesh;

        Radius = 25.0f;
        Angle = 95.0f;
        LineAngle = 1;
    }

    private void Update()
    {
        TargetList.Clear();

        //OverlapSphere(Vector3 position, float radius, int layerMask);
        Collider[] InTargets = Physics.OverlapSphere(transform.position, Radius, TargetMask);

        for (int i = 0; i < InTargets.Length; ++i)
        {
            Transform Target = InTargets[i].transform;

            Vector3 TargetDirection = (Target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, TargetDirection) < Angle / 2)
            {
                float TargetDistance = Vector3.Distance(transform.position, Target.position);

                if (!Physics.Raycast(transform.position, TargetDirection, TargetDistance, OnstacleMask))
                    TargetList.Add(Target);

                
            }
        }
    }
    private void LateUpdate()
    {
        //Mathf.RoundToInt = �Ǽ��� ���� ���� ������ ������ ��ȯ
        //Angle = 95, LineAngle = 1
        //LineCount = 95/1
        //LineCount 95
        int LineCount = Mathf.RoundToInt(Angle / LineAngle);

        //LineCount = 95
        //Angle = 95
        //AngleSize = 1
        float AngleSize = Angle / LineCount;

        //���ý� ���� ����Ʈ
        List<Vector3> ViewPointList = new List<Vector3>();

        //ViewPointListȮ��
        for (int i = 0; i < LineCount - 1; ++i)
        {
            float ViewAngle = transform.eulerAngles.y - (Angle / 2) + AngleSize * i;

            ViewCastInfo tViewCast = ViewCast(ViewAngle);

            ViewPointList.Add(tViewCast.Point);
        }


        //��� ���ؽ��� ������ Ȯ��
        int VertexCount = ViewPointList.Count + 1;

        //96���� �������
        Vector3[] VertexList = new Vector3[VertexCount];
        VertexList[0] = Vector3.zero;

        // (VertexCount - 2) = �ﰢ���� ����
        // (VertexCount - 2) * 3 �ﰢ���� �׸��� ���� ���ؽ��� ����
        //VertexCount = 96
        //VertexCount - 2 = 94
        //(VertexCount - 2) * 3 = 282
        //Teiangle[282]�� ����
        int[] Teiangle = new int[(VertexCount - 2) * 3];

        for(int i = 0; i<VertexCount -1;++i)
        {
            //InverseTransformPoint(������ǥ) = ������ǥ ��ȯ�Լ�
            VertexList[i + 1] = transform.InverseTransformPoint(ViewPointList[i]);

            if(i < VertexCount - 2)
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

    public Vector3 LocalViewAngle(float _Angle)
    {
        _Angle += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(_Angle * Mathf.Deg2Rad), 0.0f, Mathf.Cos(_Angle * Mathf.Deg2Rad));
    }
    
    public Vector3 DirectionAngle(float _Angle)
    {
        return new Vector3(Mathf.Sin(_Angle * Mathf.Deg2Rad), 0.0f, Mathf.Cos(_Angle * Mathf.Deg2Rad));
    }

    public ViewCastInfo ViewCast(float _Angle)
    {
        Vector3 Direction = DirectionAngle(_Angle);

        RaycastHit Hit;

        if(Physics.Raycast(transform.position, Direction, out Hit, Radius, OnstacleMask))
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
}
