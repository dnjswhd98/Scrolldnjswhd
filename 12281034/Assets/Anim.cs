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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Anime.SetFloat("Speed",Input.GetAxis))
    }
}
