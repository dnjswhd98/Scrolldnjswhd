using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaketTop : MonoBehaviour
{
    private bool Moving;
    private Animator Anime;

    void Start()
    {
        Moving = false;
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
        Anime.SetBool("Moving", Moving);
    }
}
