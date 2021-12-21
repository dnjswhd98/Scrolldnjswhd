using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMove : MonoBehaviour
{
    public bool Hit;
    public bool FindPlayer;
    public bool Move;
    private bool Dead;
    private Vector3 Direction;
    private Animator Anime;
    private Rigidbody2D Rigid;
    private GameObject Player;
    [SerializeField] private int NodeNum;

    private float angle;

    private Vector2 target;

    [SerializeField] private GameObject MovePoint;

    [SerializeField] private List<GameObject> WayPointList;

    void Start()
    {
        MovePoint = GameObject.Find("DogsWayPoint");

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

        if (!FindPlayer)
        {
            if (MovePoint)
            {
                if (WayPointList.Count < MovePoint.transform.childCount)
                {
                    for (int i = 1; i < MovePoint.transform.childCount + 1; ++i)
                        WayPointList.Add(MovePoint.transform.Find("W" + i).gameObject);
                }

                angle = Mathf.Atan2(WayPointList[NodeNum].transform.position.y - target.y,
                    WayPointList[NodeNum].transform.position.x - target.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                if (!Move)
                    Move = true;

            }
        }

        if (Hit)
        {
            Rigid.AddForce(Direction * 1000);
            Dead = true;
        }

        if (Dead)
        {
            Hit = false;
            Move = false;
            transform.GetComponent<BoxCollider2D>().enabled = false;
            Singleton.EnemyList.Remove(transform.gameObject);
        }

        if (FindPlayer && !Dead)
        {
            angle = Mathf.Atan2(Player.transform.position.y - target.y, Player.transform.position.x - target.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Move = true;
        }

        if (Move)
        {
            if(!FindPlayer)
                transform.Translate(Vector3.right * 5.0f * Time.deltaTime, Space.Self);
            else
                transform.Translate(Vector3.right * 8.0f * Time.deltaTime, Space.Self);
        }
        Anime.SetBool("Dead", Dead);
        Anime.SetBool("FindPlayer", FindPlayer);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "W" + (NodeNum + 1))
        {
            ++NodeNum;
            if (NodeNum > WayPointList.Count - 1)
                NodeNum = 0;
        }

    }
}
