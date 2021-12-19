using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float Speed = 1000.0f;
    private Rigidbody2D Rigid;
    private GameObject Player;

    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        Rigid.AddForce(transform.right * Speed);
    }

    private void OnEnable()
    {
        Rigid.AddForce(transform.right * Speed);
    }

    private void Update()
    {
        Player = GameObject.FindWithTag("player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Walls" || collision.transform.tag == "Enemy")
        {
            Singleton.GetInstance.GetEnableList.Remove(this.gameObject);
            this.gameObject.SetActive(false);
            Singleton.GetInstance.GetDisableList.Push(this.gameObject);

            if(collision.transform.tag == "Enemy")
            {
                collision.transform.Find("MafiaTop").GetComponent<MafiaMoveTest>().PlayerWeapon =
                    Player.transform.Find("JaketTop").GetComponent<JaketTop>().WeaponNum;
                collision.transform.Find("MafiaTop").GetComponent<MafiaMoveTest>().Hit = true;
            }
        }
    }
}
