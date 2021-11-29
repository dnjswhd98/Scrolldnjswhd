using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 Direction;

    Animator Anime;

    void Start()
    {
        Anime = transform.GetComponent<Animator>();
    }

    void Update()
    {
        float Hor = Input.GetAxisRaw("Horizontal");

        if (Hor != 0)
        {

            if (Hor < 0)
            {
                Direction = transform.localScale;

                Direction.x = -Mathf.Abs(Direction.x);

                transform.localScale = Direction;
            }
            else
            {
                Direction = transform.localScale;

                Direction.x = Mathf.Abs(Direction.x);

                transform.localScale = Direction;
            }

        }

        transform.Translate(new Vector3(Hor * 5.0f * Time.deltaTime,0.0f,0.0f));

        //if (Hor < 0)
        //    Hor *= -1;
        Anime.SetFloat("Hor", Hor);
    }
}
