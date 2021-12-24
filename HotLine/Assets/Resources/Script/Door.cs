using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Vector3 DoorPosition;
    private Vector3 PlayerPos;
    private Vector3 Temp;
    private Quaternion DoorRot;
    [SerializeField]private Quaternion LRot;

    void Start()
    {
        DoorRot = transform.rotation;
        LRot.z = DoorRot.z + 110.0f;
        DoorPosition = transform.position;
    }

    void Update()
    {
        transform.position = DoorPosition;
        if(transform.rotation.z >= DoorRot.z + 110.0f)
        {
            transform.eulerAngles = new Vector3(0.0f, 0.0f, DoorRot.z + 110.0f);
        }
        else if(transform.rotation.z <= DoorRot.z - 110.0f)
        {
            transform.eulerAngles = new Vector3(0.0f, 0.0f, DoorRot.z - 110.0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "player")
        {
            PlayerPos = collision.transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            //Move = true;
            Temp = transform.position - PlayerPos.normalized;
            Temp.x = 0.0f;
            GetComponent<Rigidbody2D>().AddForce(Temp * -2.0f);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
    }
}
