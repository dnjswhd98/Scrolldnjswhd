using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MafiaMove : MonoBehaviour
{
    private bool Walking;
    private bool FindPlayer;
    public bool Dead;
    private Animator Anime;

    public float Radius;
    [Range(0,360)]public float Angle;

    private LayerMask TargetMask;
    private LayerMask OnstacleMask;

    private int LineAngle = 0;

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
        Anime = GetComponent<Animator>();

        Radius = 25.0f;
        Angle = 95.0f;
        LineAngle = 1;
    }

    void Update()
    {
        Collider[] InTargets = Physics.OverlapSphere(transform.position, Radius, TargetMask);

        for(int i = 0;i<InTargets.Length;++i)
        {
            Transform Target = InTargets[i].transform;

            Vector3 TargetDirection = (Target.position - transform.position).normalized;

            if(Vector3.Angle(transform.right,TargetDirection)<Angle / 2)
            {
                float TargetDistance = Vector3.Distance(transform.position, Target.position);

                //if(!Physics.Raycast(transform.position,TargetDirection,TargetDistance,OnstacleMask))
                //    Ta
            }
        }

        if(Dead)
        {
        }

        Anime.SetBool("Dead", Dead);
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

        if (Physics.Raycast(transform.position, Direction, out Hit, Radius, OnstacleMask))
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
