using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MafiaMoveTest : MonoBehaviour
{
    static public bool Dead;
    private Animator Anime;
    private Rigidbody2D Rigid;

    void Start()
    {
        Anime = GetComponent<Animator>();
        Rigid = transform.parent.GetComponent<Rigidbody2D>();
        Dead = false;
    }

    void Update()
    {
        

        Anime.SetBool("Dead", Dead);
    }
}
