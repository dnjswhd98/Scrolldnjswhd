using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoCon : MonoBehaviour
{
    [SerializeField]private bool jump;
    [SerializeField]private bool dead;
    private float jumpSpeed;
    Animator Anime;

    void Start()
    {
        Anime = transform.GetComponent<Animator>();
        jump = false;
        dead = false;
        jumpSpeed = 350.0f;
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !jump)
        {
            jump = true;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed);
        }
        
        Anime.SetBool("Dead", dead);
        Anime.SetBool("jump", jump);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Graund")
        {
            jumpSpeed = 350.0f;
            jump = false;
        }
        if (collision.transform.tag == "Obj")
        {
            dead = true;
            Debug.Log("dead");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Obj")
        {
            dead = true;
            Debug.Log("dead");
        }
    }
    public bool getDead() { return dead; }
}
