using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SempleCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�浹");
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("�浹��...");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("�浹 ����");
    }

    //Collider�� ������ ����
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("�浹");
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("�浹��...");
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("�浹 ����");
    }
}
