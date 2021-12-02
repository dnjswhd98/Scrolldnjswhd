using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoCon : MonoBehaviour
{
    [SerializeField]private bool jump;
    [SerializeField]private bool dead;
    private float jumpSpeed;

    void Start()
    {
        jump = false;
        dead = false;
        jumpSpeed = 7000.0f;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if (jumpSpeed <= 10000.0f)
            {
                ++jumpSpeed;
                jump = true;
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpSpeed * Time.deltaTime);
            }  
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Graund")
        {
            jumpSpeed = 10000.0f;
            jump = false;
        }
        if (collision.transform.tag == "Obj")
        {
            dead = true;
        }

    }
}
