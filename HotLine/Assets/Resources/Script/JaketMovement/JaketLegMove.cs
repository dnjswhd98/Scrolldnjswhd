using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaketLegMove : MonoBehaviour
{
    private bool Moving;
    private Vector3 Target;
    private float Hor;
    private float Ver;
    private Animator Anime;
    public bool Dead;

    void Start()
    {
        Dead = false;
        Moving = false;
        Anime = GetComponent<Animator>();
    }

    void Update()
    {
        if (!Dead)
        {
            Hor = Input.GetAxis("Horizontal");
            Ver = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
            {
                Moving = true;
            }
            else
            {
                Moving = false;
            }
        }
        Anime.SetBool("Moving", Moving);
        Anime.SetBool("Dead", Dead);
    }
}
