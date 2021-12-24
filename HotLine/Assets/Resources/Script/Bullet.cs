using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float Speed = 2000.0f;
    private Rigidbody2D Rigid;
    private GameObject Player;
    public GameObject FireTo;

    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        Rigid.AddForce(transform.right * Speed);
    }

    private void OnDisable()
    {
        FireTo = null;
    }

    private void OnEnable()
    {
        if (gameObject.activeSelf)
            Rigid.AddForce(transform.right * Speed);
    }

    private void Update()
    {
        Player = GameObject.FindWithTag("player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Walls" || collision.transform.tag == "Door")
        {
            DisableBullet();
        }

        if (FireTo.transform.tag == "player")
        {
            if (collision.transform.tag == "Enemy")
            {
                DisableBullet();

                collision.transform.Find("MafiaTop").GetComponent<MafiaMoveTest>().PlayerWeapon =
                    Player.transform.Find("JaketTop").GetComponent<JaketTop>().WeaponNum;
                collision.transform.Find("MafiaTop").GetComponent<MafiaMoveTest>().Hit = true;

            }
            else if(collision.transform.tag == "Dog")
            {
                DisableBullet();

                collision.GetComponent<DogMove>().Hit = true;

            }
        }
        else if (FireTo.transform.tag == "Enemy")
        {
            if (collision.transform.tag == "player")
            {
                DisableBullet();
            }
        }
    }

    void DisableBullet()
    {
        Singleton.GetInstance.GetEnableList.Remove(gameObject);
        this.gameObject.SetActive(false);
        Singleton.GetInstance.GetDisableList.Push(gameObject);
    }
}
