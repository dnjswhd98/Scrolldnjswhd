using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaketMoving : MonoBehaviour
{
    private GameObject Mouse;

    float angle;
    Vector2 target;

    void Update()
    {
        target = transform.position;

        Mouse = GameObject.Find("MouseCursor");

        if (Input.GetKey(KeyCode.W))
            transform.Translate(new Vector3(0.0f, 0.1f, 0.0f), Space.World);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(new Vector3(0.0f, -0.1f, 0.0f), Space.World);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(new Vector3(-0.1f, 0.0f, 0.0f), Space.World);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(new Vector3(0.1f, 0.0f, 0.0f), Space.World);

        angle = Mathf.Atan2(Mouse.transform.position.y - target.y, Mouse.transform.position.x - target.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Camera.main.transform.position = new Vector3(transform.position.x,transform.position.y, Camera.main.transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Walls")
        {
            Debug.Log("Wall");
        }
        if(collision.transform.tag == "Door")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 500.0f);
        }
    }
}
