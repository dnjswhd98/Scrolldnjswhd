using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaketTop : MonoBehaviour
{
    private bool Moving;
    static public Animator Anime;
    private bool Attack;
    private int WeaponNum;
    private SpriteRenderer SRenderer;
    private GameObject Mouse;
    
    void Start()
    {
        Moving = false;
        Attack = false;
        Anime = GetComponent<Animator>();
        WeaponNum = 1;
        SRenderer = GetComponent<SpriteRenderer>();
        Mouse = GameObject.Find("MouseCurser");
        GameObject obj = Resources.Load("Prefap/WeaponItem/Bat") as GameObject;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
        {
            Moving = true;
        }
        else
        {
            Moving = false;
        }

        if (Input.GetMouseButtonDown(0) && !Attack)
        {
            Attack = true;
            if(WeaponNum > 0)
            {
                Invoke("SetAtkFlip", 0.26f);
            }
        }
        else
        {
        }

        if (Input.GetMouseButtonDown(1) && WeaponNum > 0)
        {
            switch(WeaponNum)
            {
                case 1:
                    GameObject obj = Resources.Load("Prefap/WeaponItem/Bat") as GameObject;
                    obj.transform.position = transform.position;
                    Instantiate(obj);
                    //obj.GetComponent<Rigidbody2D>().AddForce((transform.position - Mouse.transform.position).normalized * 10.0f);
                    break;
                case 2:

                    break;
                default:
                    break;
            }
            WeaponNum = 0;
            if (SRenderer.flipY)
                SRenderer.flipY = false;
        }

        Anime.SetBool("Moving", Moving);
        Anime.SetBool("Attack", Attack);
        Anime.SetInteger("Weapon", WeaponNum);
    }

    void SetAtkFlip()
    {
        Attack = false;

        //if (SRenderer.flipY)
        //    SRenderer.flipY = false;
        //else
        //    SRenderer.flipY = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Attack)
        {
            if (collision.tag == "Enemy")
                collision.transform.Find("MafiaTop").GetComponent<MafiaMoveTest>().Hit = true;
            if (collision.tag == "Dog")
                collision.GetComponent<DogMove>().Hit = true;
        }
    }
}
