using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MafiaMovement : MonoBehaviour
{
    public bool FindPlayer;
    public bool Move;
    [SerializeField]private bool Dead;
    [SerializeField]private int NodeNum;
    private float angle;

    private Vector2 target;

    private GameObject Player;
    public GameObject MovePoint;

    private Animator EnemyLeg;

    [SerializeField]private List<GameObject> WayPointList;

    private void Awake()
    {
        FindPlayer = false;
        Move = false;
    }

    void Start()
    {
        EnemyLeg = transform.Find("MafiaLeg").GetComponent<Animator>();
        WayPointList = new List<GameObject>();
        NodeNum = 0;
        Dead = false;
    }

    void Update()
    {
        if (transform.Find("MafiaTop").GetComponent<MafiaMoveTest>().Dead)
        {
            Dead = true;
            Move = false;
        }
        else
        {
            if (!FindPlayer)
            {
                if (MovePoint)
                {
                    EnemyWayPoint();
                }
            }

            target = transform.position;
            Player = GameObject.Find("Jaket(Clone)");

            if (FindPlayer)
            {
                angle = Mathf.Atan2(Player.transform.position.y - target.y, Player.transform.position.x - target.x) * Mathf.Rad2Deg;
                this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                Move = true;
                if (GameObject.FindWithTag("player").GetComponent<JaketMoving>().Dead)
                {
                    FindPlayer = false;
                    Move = false;
                }
            }

            if (Move)
            {
                if (!FindPlayer)
                {
                    transform.Translate(Vector3.right * 5.0f * Time.deltaTime, Space.Self);
                }
                else
                {
                    if (!transform.Find("MafiaTop").GetComponent<MafiaMoveTest>().Stop)
                    {
                        transform.Translate(Vector3.right * 5.0f * Time.deltaTime, Space.Self);
                    }
                }
            }
        }
        EnemyLeg.SetBool("Walking", Move);
        EnemyLeg.SetBool("Dead", Dead);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!FindPlayer && WayPointList.Count == 0)
        {
            if(collision.transform.tag == "Wall")
            {
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, 45.0f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "WayPoint")
        {
            if (collision.transform.name == "W" + (NodeNum + 1))
            {
                ++NodeNum;
                if (NodeNum > WayPointList.Count - 1)
                    NodeNum = 0;
            }
        }
    }

    private void EnemyWayPoint()
    {
        if (MovePoint.name == "Enemy1Point" && gameObject.name == "Enemy1(Clone)")
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
        else if (MovePoint.name == "Enemy2Point" && gameObject.name == "Enemy7(Clone)")
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
        else if (MovePoint.name == "Enemy8Point" && gameObject.name == "Enemy8(Clone)")
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
}
