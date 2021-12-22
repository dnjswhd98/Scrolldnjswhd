using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItems : MonoBehaviour
{
    public int WeaponItemNum;
    private Rigidbody2D Rigid;
    public bool Throw;
    public bool Drop;
    private float Speed = 700.0f;
    Vector3 lastVelocity;


    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        if (Throw)
        {
            Rigid.AddForce(transform.right * Speed);
            transform.Rotate(new Vector3(0.0f, 0.0f, 360.0f), Space.Self);
        }

    }

    void Update()
    {
        lastVelocity = Rigid.velocity;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(Throw)
        {
            if (collision.transform.tag == "Walls")
            {
                var speed = lastVelocity.magnitude;
                var dir = Vector2.Reflect(lastVelocity.normalized, collision.bounds.ClosestPoint(transform.position).normalized);
                Rigid.velocity = dir * Mathf.Max(speed, 0f);

            }
        }
        
    }
}
