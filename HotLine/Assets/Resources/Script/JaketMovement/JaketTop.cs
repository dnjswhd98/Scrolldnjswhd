using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaketTop : MonoBehaviour
{
    private bool Moving;
    private bool Attack;
    private bool GetGun;
    public bool Dead;
    public int EnemyWeapon;

    private int DoubleBAttack;
    private int BulletCount;
    public int WeaponNum;
    public bool GetNewWeapon;

    static public Animator Anime;

    public int MaxRound;
    public int Round;

    private SpriteRenderer SRenderer;
    private GameObject BulletParent;
    private int FireTime;

    private void Awake()
    {
        BulletParent = new GameObject("BulletParent");
    }

    void Start()
    {
        FireTime = 0;
        Moving = false;
        Attack = false;
        GetGun = false;
        Dead = false;
        GetNewWeapon = true;

        EnemyWeapon = 0;

        Anime = GetComponent<Animator>();

        WeaponNum = 1;

        BulletCount = 0;
        MaxRound = 0;
        Round = 0;
        DoubleBAttack = 0;

        SRenderer = GetComponent<SpriteRenderer>();

        if(WeaponNum >= 7)
            GetGunRound();
    }

    void Update()
    {
        if (!Dead)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
            {
                Moving = true;
            }
            else
            {
                Moving = false;
            }

            if (GetGun)
                GetGunRound();

            if (WeaponNum >= 0 && WeaponNum < 7)
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
                if (WeaponNum == 8 || WeaponNum == 9)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (Round > 0)
                        {
                            if (!Attack)
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
                                BulletObj.GetComponent<Bullet>().FireTo = gameObject;

                                BulletObj.SetActive(true);

                                Singleton.GetInstance.GetEnableList.Add(BulletObj);
                            }
                            if (WeaponNum == 8)
                                Singleton.GetInstance.PlayingSound(20);
                            else
                                Singleton.GetInstance.PlayingSound(8);

                            --Round;
                            ++DoubleBAttack;
                            if (DoubleBAttack > 1)
                                DoubleBAttack = 0;
                        }
                    }
                    else
                    {
                        Attack = false;
                        FireTime = 0;
                    }
                }
                else
                {
                    if (Input.GetMouseButton(0))
                    {
                        if (Round > 0)
                        {
                            if (!Attack)
                            {
                                Attack = true;
                                FireTime = 1;
                            }

                            if (FireTime == 0 && Round > 0)
                            {
                                if (Singleton.GetInstance.GetDisableList.Count == 0)
                                {
                                    for (int i = 0; i < MaxRound; ++i)
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

                                Singleton.GetInstance.PlayingSound(13);

                                Singleton.GetInstance.GetEnableList.Add(BulletObj);

                                --Round;
                            }

                            ++FireTime;

                            if (FireTime > 6)
                                FireTime = 0;
                        }
                    }

                    else
                    {
                        Attack = false;
                        FireTime = 0;
                    }
                }
            }

            if (Input.GetMouseButtonDown(1) && WeaponNum > 0 && !GetNewWeapon)
            {
                switch (WeaponNum)
                {
                    case 1:
                        {
                            GameObject obj = Resources.Load("Prefap/WeaponItem/Bat") as GameObject;
                            obj.transform.position = transform.position;
                            obj.transform.rotation = transform.rotation;
                            obj.GetComponent<WeaponItems>().Throw = true;
                            obj.GetComponent<WeaponItems>().WeaponItemNum = WeaponNum;
                            Instantiate(obj);
                        }
                        break;
                    case 2:
                        {
                            GameObject obj = Resources.Load("Prefap/WeaponItem/Club") as GameObject;
                            obj.transform.position = transform.position;
                            obj.transform.rotation = transform.rotation;
                            obj.GetComponent<WeaponItems>().Throw = true;
                            obj.GetComponent<WeaponItems>().WeaponItemNum = WeaponNum;
                            Instantiate(obj);
                        }
                        break;
                    case 3:
                        {
                            GameObject obj = Resources.Load("Prefap/WeaponItem/Knife") as GameObject;
                            obj.transform.position = transform.position;
                            obj.transform.rotation = transform.rotation;
                            obj.GetComponent<WeaponItems>().Throw = true;
                            obj.GetComponent<WeaponItems>().WeaponItemNum = WeaponNum;
                            Instantiate(obj);
                        }
                        break;
                    case 7:
                        {
                            GameObject obj = Resources.Load("Prefap/WeaponItem/M16") as GameObject;
                            obj.transform.position = transform.position;
                            obj.transform.rotation = transform.rotation;
                            obj.GetComponent<WeaponItems>().Throw = true;
                            obj.GetComponent<WeaponItems>().WeaponItemNum = WeaponNum;
                            Instantiate(obj);
                        }
                        break;
                    case 8:
                        {
                            GameObject obj = Resources.Load("Prefap/WeaponItem/Shotgun") as GameObject;
                            obj.transform.position = transform.position;
                            obj.transform.rotation = transform.rotation;
                            obj.GetComponent<WeaponItems>().Throw = true;
                            obj.GetComponent<WeaponItems>().WeaponItemNum = WeaponNum;
                            Instantiate(obj);
                        }
                        break;
                    case 9:
                        {
                            GameObject obj = Resources.Load("Prefap/WeaponItem/DoubleB") as GameObject;
                            obj.transform.position = transform.position;
                            obj.transform.rotation = transform.rotation;
                            obj.GetComponent<WeaponItems>().Throw = true;
                            obj.GetComponent<WeaponItems>().WeaponItemNum = WeaponNum;
                            Instantiate(obj);
                        }
                        break;
                    default:
                        break;
                }
                WeaponNum = 0;
                if (SRenderer.flipY)
                    SRenderer.flipY = false;
            }
        }
        else
        {
            transform.parent.GetComponent<JaketMoving>().Dead = true;
        }

        if (GetNewWeapon)
            GetNewWeapon = false;

        Anime.SetBool("Moving", Moving);
        Anime.SetBool("Attack", Attack);
        Anime.SetInteger("Weapon", WeaponNum);
        Anime.SetInteger("DoubleBAttack", DoubleBAttack);
        Anime.SetBool("Dead", Dead);
        Anime.SetInteger("EnemyWeapon", EnemyWeapon);
    }

    private void SetAtkFlip()
    {
        Attack = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Attack)
        {
            if (collision.tag == "Enemy")
            {
                collision.transform.Find("MafiaTop").GetComponent<MafiaMoveTest>().PlayerWeapon = WeaponNum;
                collision.transform.Find("MafiaTop").GetComponent<MafiaMoveTest>().Hit = true;
                Singleton.GetInstance.PlayingSound(11);

            }
            else if (collision.tag == "Dog")
            {
                collision.gameObject.GetComponent<DogMove>().Hit = true;
                Singleton.GetInstance.PlayingSound(11);
            }
        }
        if (collision.transform.tag == "Item")
        {
            if (WeaponNum == 0)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    GetComponent<JaketTop>().WeaponNum = collision.gameObject.GetComponent<WeaponItems>().WeaponItemNum;
                    Destroy(collision.gameObject);
                    GetNewWeapon = true;
                    GetGun = true;
                }
            }
        }
    }

    private void GetGunRound()
    {
        if (WeaponNum >= 7)
        {
            switch (WeaponNum)
            {
                case 7:
                    MaxRound = 24;
                    Round = 24;
                    break;
                case 8:
                    MaxRound = 6;
                    Round = 6;
                    break;
                case 9:
                    MaxRound = 2;
                    Round = 2;
                    break;
                case 10:
                    MaxRound = 30;
                    Round = 30;
                    break;
                default:
                    break;
            }
            GetGun = false;
        }
    }
}
