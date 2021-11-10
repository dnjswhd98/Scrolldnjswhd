using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveB : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 2000.0f);
    }

    void Update()
    {
        
    }
}
