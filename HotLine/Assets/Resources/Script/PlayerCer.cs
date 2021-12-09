using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCer : MonoBehaviour
{
    private bool AroundCar;
    private bool InCar;
    private Animator Anime;

    void Start()
    {
        AroundCar = false;
        InCar = false;
        Anime = GetComponent<Animator>();
    }

    void Update()
    {
        Anime.SetBool("AroundCar", AroundCar);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "player")
        {
            AroundCar = true;
        }
        else
            AroundCar = false;
    }
}
