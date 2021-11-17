using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizmo : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //DrawSphere(Vector3 center, float radius);
        Gizmos.DrawSphere(transform.position, 0.2f);
    }
}
