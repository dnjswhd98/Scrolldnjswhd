using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//자동으로 해당 컴퍼넌트 추가
[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 200.0f);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.name == "Wall")
    //        Destroy(this.gameObject);
    //}
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
}
