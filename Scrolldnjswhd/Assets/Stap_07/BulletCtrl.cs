using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{

    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 2000.0f);
    }

    private void OnEnable()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 2000.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Wall")
        {
            SampleObjectManager.GetInstance.GetEnableList.Remove(this.gameObject);
            this.gameObject.SetActive(false);
            SampleObjectManager.GetInstance.GetDisableList.Push(this.gameObject);
        }
    }
}
