using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ڵ����� �ش� ���۳�Ʈ �߰�
[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 2000.0f);
    }
}
