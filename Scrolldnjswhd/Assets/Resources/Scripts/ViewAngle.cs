using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewAngle : MonoBehaviour
{
    [Tooltip("시야 최대 거리")]
    public float Radius;
    [Tooltip("시야 최대 각도")]
    [Range(0, 360)] public float Angle;

    [Tooltip("TargetLayerMask")]
    [SerializeField] private LayerMask TargetMask;
    [Tooltip("ObstacleLayerMask")]
    [SerializeField] private LayerMask OnstacleMask;

    [Tooltip("TargetList")]
    //[HideInInspector] //inspectorview에서 숨김
    public List<Transform> TargetList = new List<Transform>();

    private void Start()
    {
        Radius = 25.0f;
        Angle = 95.0f;
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

    public Vector3 LocalViewAngle(float _Angle)
    {
        return new Vector3(Mathf.Sin(_Angle * Mathf.Deg2Rad), 0.0f, Mathf.Cos(_Angle * Mathf.Deg2Rad));
    }
}
