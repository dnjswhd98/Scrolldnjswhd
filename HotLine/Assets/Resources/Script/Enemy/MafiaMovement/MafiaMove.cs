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
    [SerializeField]private LayerMask OnstacleMask;
    [SerializeField]private Collider[] InTargets;

    private Vector2 Direction;

    private float LineAngle = 0;

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
        Direction = transform.right;

        Anime = GetComponent<Animator>();

        OnstacleMask = LayerMask.GetMask("Player");

        Radius = 25.0f;
        Angle = 0.0f;
        LineAngle = 1;
    }

    void Update()
    {
        
        for (int i = 0; i < 24; ++i)
        {
            float Tangle;
            if (i < 12)
            {
                Tangle = Angle + (LineAngle * i);
                if (Physics2D.Raycast(transform.position, GetDistancee(), Radius, OnstacleMask))
                    Debug.Log(GetDistancee());
            }
            else
            {
                Tangle = Angle - (LineAngle * i);
                if (Physics2D.Raycast(transform.position, GetDistancee(), Radius, OnstacleMask))
                    Debug.Log(GetDistancee());
            }
        }

        if(Dead)
        {
        }

        //Anime.SetBool("Dead", Dead);
    }

    public Vector2 LocalViewAngle(float _Angle)
    {
        _Angle += transform.eulerAngles.y;
        return new Vector2(Mathf.Sin(_Angle * Mathf.Deg2Rad), Mathf.Cos(_Angle * Mathf.Deg2Rad));
    }

    public Vector2 DirectionAngle(float _Angle)
    {
        return new Vector2(Mathf.Sin(_Angle * Mathf.Deg2Rad), Mathf.Cos(_Angle * Mathf.Deg2Rad));
    }

    private Vector2 GetDistancee()
    {
        Vector3 direction = transform.right;

        var quaternion = Quaternion.Euler(Angle, 0, 0);
        Vector3 newDirection = quaternion * direction;

        return newDirection; 
    }
}
