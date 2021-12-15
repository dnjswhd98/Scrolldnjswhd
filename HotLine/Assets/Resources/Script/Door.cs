using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Vector3 DoorPosition;

    void Start()
    {
        DoorPosition = transform.position;
    }

    void Update()
    {
        transform.position = DoorPosition;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.transform.tag == "player")
        //{
        //    transform.Rotate(Vector3.forward * 10);
        //}
    }
}
