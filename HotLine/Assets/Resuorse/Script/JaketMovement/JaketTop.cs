using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaketTop : MonoBehaviour
{
    private bool Moving;
    static public Animator Anime;
    private bool Attack;

    void Start()
    {
        Moving = false;
        Attack = false;
        Anime = GetComponent<Animator>();
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
        if (Input.GetMouseButtonDown(0))
        {
            Attack = true;
        }
        else
        {
            Attack = false;
        }
        Anime.SetBool("Moving", Moving);
        Anime.SetBool("Attack", Attack);
    }
}
