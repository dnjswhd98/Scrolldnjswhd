using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaketMoving : MonoBehaviour
{
    private GameObject Mouse;
    private bool Move;

    float angle;
    Vector2 target;

    private void Start()
    {
        Move = true;
    }

    void Update()
    {
        target = transform.position;

        Mouse = GameObject.Find("MouseCursor");
        if (Move)
        {
            if (Input.GetKey(KeyCode.W))
                transform.Translate(new Vector3(0.0f, 0.1f, 0.0f), Space.World);
            if (Input.GetKey(KeyCode.S))
                transform.Translate(new Vector3(0.0f, -0.1f, 0.0f), Space.World);
            if (Input.GetKey(KeyCode.A))
                transform.Translate(new Vector3(-0.1f, 0.0f, 0.0f), Space.World);
            if (Input.GetKey(KeyCode.D))
                transform.Translate(new Vector3(0.1f, 0.0f, 0.0f), Space.World);
        }
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
        


        if (collision.transform.tag == "Door")
        {
            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(collision.transform.up * -500.0f);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
    
        if (collision.transform.tag == "Item")
        {
            if (Input.GetMouseButtonDown(1))
            {
                transform.Find("JaketTop").GetComponent<JaketTop>().WeaponNum = collision.gameObject.GetComponent<WeaponItems>().WeaponItemNum;
                Destroy(collision.gameObject);
            }
        }
    }
}
