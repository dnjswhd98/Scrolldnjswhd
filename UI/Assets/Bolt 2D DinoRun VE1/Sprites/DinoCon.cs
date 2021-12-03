using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoCon : MonoBehaviour
{
    [SerializeField]private bool jump;
    static public bool dead;
    private float jumpSpeed;
    private Animator Anime;
    static public Rigidbody2D rigid2d;

    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
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
            rigid2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
