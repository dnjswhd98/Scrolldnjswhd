using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMove : MonoBehaviour
{
    public bool Hit;
    public bool FindPlayer;
    private bool Dead;
    private Vector3 Direction;
    private Animator Anime;
    private Rigidbody2D Rigid;
    private GameObject Player;

    private float angle;

    private Vector2 target;

    void Start()
    {
        Anime = GetComponent<Animator>();
        Rigid = GetComponent<Rigidbody2D>();
        Hit = false;
        Dead = false;
    }

    void Update()
    {
        target = transform.position;

        Player = GameObject.FindWithTag("player");
        Direction = (transform.position - Player.transform.position).normalized;
        if (Hit)
        {
            Rigid.AddForce(Direction * 1000);
            Dead = true;
        }

        if (Dead)
        {
            Hit = false;
            transform.GetComponent<BoxCollider2D>().isTrigger = true;
        }

        if(FindPlayer && !Dead)
        {
            angle = Mathf.Atan2(Player.transform.position.y - target.y, Player.transform.position.x - target.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.Translate(Vector3.right * 5.0f * Time.deltaTime, Space.Self);
        }

        Anime.SetBool("Dead", Dead);
        Anime.SetBool("FindPlayer", FindPlayer);
    }
}
