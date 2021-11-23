using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointBase : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Graund")
        {
            transform.position = new Vector3(
                Random.Range(WayPointManager.GetInstance().PointA.x, WayPointManager.GetInstance().PointB.x),
                5.0f,
                Random.Range(WayPointManager.GetInstance().PointA.y, WayPointManager.GetInstance().PointB.y));
        }
    }
}
