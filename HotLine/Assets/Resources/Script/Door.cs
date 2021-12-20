using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Vector3 DoorPosition;
    private Quaternion DoorRote;
    private Quaternion MaxRote;

    void Start()
    {
        DoorPosition = transform.position;
        DoorRote = transform.rotation;
        MaxRote = Quaternion.Euler(0.0f, 0.0f, 120.0f);
    }

    void Update()
    {
        transform.position = DoorPosition;
        //if(transform.rotation.z < DoorRote.z + MaxRote.z || transform.rotation.z < DoorRote.z + MaxRote.z)
        //{
        //
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.transform.tag == "player")
        //{
        //    transform.Rotate(Vector3.forward * 10);
        //}
    }
}
