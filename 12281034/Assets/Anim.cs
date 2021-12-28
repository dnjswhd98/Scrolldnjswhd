using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anim : MonoBehaviour
{
    private Animator Anime;

    private void Awake()
    {
        Anime = transform.GetComponent<Animator>();
    }

    void Update()
    {
        Anime.SetFloat("Speed", Input.GetAxis("Vertical"));
        Anime.SetFloat("Hor", Input.GetAxis("Horizontal"));
    }
}
