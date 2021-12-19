using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MafiaMoveTest : MonoBehaviour
{
    private bool Dead;
    public bool Hit;
    public bool FindPlayer;
    public int PlayerWeapon;
    private int Deadrand;

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
    }

    void Update()
    {
        Player = GameObject.Find("Jaket(Clone)");
        Direction = (transform.position - Player.transform.position).normalized;
        if(Hit)
        {
            Rigid.AddForce(Direction * 1000);
            Dead = true;

            if (PlayerWeapon >= 7)
            {
                Deadrand = Random.Range(0, 4);
            }
        }

        if (Dead)
        {
            Hit = false;
            transform.parent.GetComponent<CapsuleCollider2D>().isTrigger = true;
            transform.parent.GetComponent<MafiaMovement>().enabled = false;
            transform.parent.GetComponent<MafiaRay>().enabled = false;
            transform.parent.GetComponent<CapsuleCollider2D>().enabled = false;

            
        }

        if (FindPlayer && WeaponNum >= 7)
        {
            Attack = true;
        }

        Anime.SetBool("Dead", Dead);
        Anime.SetBool("Attack", Attack);
        Anime.SetInteger("WeaponNum", WeaponNum);
        Anime.SetInteger("PlayerWeapon", PlayerWeapon);
        Anime.SetInteger("DeadRand", Deadrand);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(FindPlayer && WeaponNum < 7)
        {
            Attack = true;
        }
    }
}
