using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MafiaMoveTest : MonoBehaviour
{
    private bool Dead;
    public bool Stop;
    public bool Hit;
    public bool FindPlayer;
    public int PlayerWeapon;
    private int Deadrand;
    private int FireTime;

    [SerializeField]private bool Attack;
    [SerializeField]public int WeaponNum;

    private Vector3 Direction;
    private Animator Anime;
    private Rigidbody2D Rigid;
    private GameObject Player;

    void Start()
    {
        Anime = GetComponent<Animator>();
        Rigid = transform.parent.GetComponent<Rigidbody2D>();
        Hit = false;
        Dead = false;
        Attack = false;
        Stop = false;
        FireTime = 0;
    }

    void Update()
    {
        Player = GameObject.Find("Jaket(Clone)");
        Direction = (transform.position - Player.transform.position).normalized;
        if(Hit)
        {
            Attack = true;
            Rigid.AddForce(Direction * 1000);
            Dead = true;

            if (PlayerWeapon >= 7)
            {
                Deadrand = Random.Range(0, 4);
            }
        }

        if (Dead)
        {
            Singleton.EnemyList.Remove(transform.parent.gameObject);
            Hit = false;
            transform.parent.GetComponent<CapsuleCollider2D>().isTrigger = true;
            transform.parent.GetComponent<MafiaMovement>().enabled = false;
            transform.parent.GetComponent<MafiaRay>().enabled = false;
            transform.parent.GetComponent<CapsuleCollider2D>().enabled = false;

        }

        if (FindPlayer && WeaponNum >= 7 && !Dead)
        {

            if (WeaponNum >= 8 && WeaponNum <= 9)
            {
                if (!Attack)
                {
                    Attack = true;
                    if (Singleton.GetInstance.GetDisableList.Count == 0)
                    {
                        for (int i = 0; i < 16; ++i)
                        {
                            GameObject obj = Instantiate(Resources.Load("Prefap/Bullet") as GameObject);
                            //++BulletCount;
                            obj.SetActive(false);

                            Singleton.GetInstance.GetDisableList.Push(obj);
                        }
                    }

                    for (int i = 0; i < 8; ++i)
                    {
                        float temp = Random.Range(-3.0f, 3.0f);
                        GameObject BulletObj = Singleton.GetInstance.GetDisableList.Pop();

                        BulletObj.transform.position = transform.position;
                        BulletObj.transform.rotation = transform.rotation * (Quaternion.Euler(0.0f, 0.0f, Random.Range(-5.0f, 5.0f)));
                        BulletObj.GetComponent<Bullet>().FireTo = transform.parent.gameObject;

                        BulletObj.SetActive(true);

                        Singleton.GetInstance.GetEnableList.Add(BulletObj);
                    }
                }
                if (FireTime == 0)
                    Attack = false;

                ++FireTime;

                if (FireTime > 100)
                    FireTime = 0;
            }
            else
            {
                if (!Attack)
                {
                    Attack = true;
                    if (Singleton.GetInstance.GetDisableList.Count == 0)
                    {
                        for (int i = 0; i < 16; ++i)
                        {
                            GameObject obj = Instantiate(Resources.Load("Prefap/Bullet") as GameObject);
                            //++BulletCount;
                            obj.SetActive(false);

                            Singleton.GetInstance.GetDisableList.Push(obj);
                        }
                    }
                    GameObject BulletObj = Singleton.GetInstance.GetDisableList.Pop();

                    BulletObj.transform.position = transform.position;
                    BulletObj.transform.rotation = transform.rotation;
                    BulletObj.GetComponent<Bullet>().FireTo = transform.parent.gameObject;

                    BulletObj.SetActive(true);

                    Singleton.GetInstance.GetEnableList.Add(BulletObj);
                }
                if (FireTime == 0)
                    Attack = false;

                ++FireTime;

                if (FireTime > 10)
                    FireTime = 0;
            }
            
        }

        Anime.SetBool("Dead", Dead);
        Anime.SetBool("Attack", Attack);
        Anime.SetInteger("WeaponNum", WeaponNum);
        Anime.SetInteger("PlayerWeapon", PlayerWeapon);
        Anime.SetInteger("DeadRand", Deadrand);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "player")
        {
            if (FindPlayer)
            {
                if (WeaponNum < 7)
                    Attack = true;
                else
                    Stop = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "player")
        {
            if (FindPlayer)
            {
                if (WeaponNum >= 7)
                    Stop = false;
            }
        }
    }
}
