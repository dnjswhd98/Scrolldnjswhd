using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MafiaRay : MonoBehaviour
{
    public float Radius;
    [Range(0,360)]public float Angle;

    [SerializeField]private LayerMask TargetMask;
    [SerializeField]private LayerMask OnstacleMask;
    [SerializeField]private Collider2D InTargets;

    void Start()
    {

        OnstacleMask = LayerMask.GetMask("Wall");
        TargetMask = LayerMask.GetMask("Player");

        Radius = 10.0f;
        Angle = 170.0f;
    }

    void Update()
    {

        InTargets = Physics2D.OverlapCircle(transform.position, Radius, TargetMask);

        if (InTargets)
        {
            Transform Target = InTargets.transform;

            Vector3 TargetDirection = (Target.position - transform.position).normalized;

            if (Vector3.Angle(transform.right, TargetDirection) < Angle / 2)
            {
                float TargetDistance = Vector3.Distance(transform.position, Target.position);

                if (!Physics2D.Raycast(transform.position, TargetDirection, TargetDistance, OnstacleMask))
                {
                    Debug.Log(transform.name + "find");
                    this.gameObject.GetComponent<MafiaMovement>().FindPlayer = true;
                    this.transform.Find("MafiaTop").GetComponent<MafiaMoveTest>().FindPlayer = true;
                }
            }
        }
    }
}
