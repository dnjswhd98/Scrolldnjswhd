using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MafiaMoveTest : MonoBehaviour
{
    private bool Dead;
    public bool Hit;
    private int WeaponNum;
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
    }

    void Update()
    {
        Player = GameObject.Find("Jaket(Clone)");
        Direction = (transform.position - Player.transform.position).normalized;
        if(Hit)
        {
            Rigid.AddForce(Direction * 1000);
            Dead = true;
        }

        if (Dead)
        {
            Hit = false;
            transform.parent.GetComponent<CapsuleCollider2D>().isTrigger = true;
            transform.parent.GetComponent<MafiaMovement>().enabled = false;
            transform.parent.GetComponent<MafiaRay>().enabled = false;
        }
        Anime.SetBool("Dead", Dead);
    }

    public void SetWeaponNum(int _Wnum) { WeaponNum = _Wnum; }
}
