using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaketTop : MonoBehaviour
{
    private bool Moving;
    static public Animator Anime;
    private bool Attack;
    public int WeaponNum;

    public int MaxRound;
    public int Round;

    private SpriteRenderer SRenderer;
    private GameObject Mouse;
    private int FireTime;

    void Start()
    {
        FireTime = 0;
        Moving = false;
        Attack = false;

        Anime = GetComponent<Animator>();

        WeaponNum = 7;

        MaxRound = 0;
        Round = 0;

        SRenderer = GetComponent<SpriteRenderer>();
        Mouse = GameObject.Find("MouseCurser");
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

        if(WeaponNum >= 7)
        {
            switch(WeaponNum)
            {
                case 7:
                    MaxRound = 24;
                    Round = 24;
                    break;
                default:
                    break;
            }
        }
        
        if(WeaponNum >= 0 && WeaponNum < 7)
        {
            if (Input.GetMouseButtonDown(0) && !Attack)
            {
                Attack = true;
                Invoke("SetAtkFlip", 0.26f);
            }
            else
            {
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {

                if (FireTime == 0)
                {
                    Attack = true;
                    GameObject Bullet = Resources.Load("Prefap/Bullet") as GameObject;
                    Bullet.transform.position = transform.position;
                    Bullet.transform.rotation = transform.rotation;
                    Instantiate(Bullet);
                    --Round;
                }

                ++FireTime;

                if (FireTime > 6)
                    FireTime = 0;
            }
            else
            {
                Attack = false;
                FireTime = 0;
            }
        }

        if (Input.GetMouseButtonDown(1) && WeaponNum > 0)
        {
            switch(WeaponNum)
            {
                case 1:
                    GameObject obj = Resources.Load("Prefap/WeaponItem/Bat") as GameObject;
                    obj.transform.position = transform.position;
                    Instantiate(obj);
                    obj.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 1000.0f);
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

    private void SetAtkFlip()
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
            else if (collision.tag == "Dog")
                collision.gameObject.GetComponent<DogMove>().Hit = true;
        }
    }
}
