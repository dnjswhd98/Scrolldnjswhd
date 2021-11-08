using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SempleCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("충돌");
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("충돌중...");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("충돌 종료");
    }

    //Collider가 있으면 반응
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌");
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("충돌중...");
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("충돌 종료");
    }
}
