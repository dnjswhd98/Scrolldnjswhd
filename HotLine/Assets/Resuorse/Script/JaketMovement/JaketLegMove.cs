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
    private Transform targetPos;

    void Start()
    {
        Moving = false;
        Anime = GetComponent<Animator>();
    }

    void Update()
    {
        Hor = Input.GetAxis("Horizontal");
        Ver = Input.GetAxis("Vertical");

        transform.LookAt(targetPos);
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
