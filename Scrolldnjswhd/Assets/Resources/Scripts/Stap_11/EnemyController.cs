using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]private Vector3 Direction;
    private float Speed;

    private bool Moving = false;

    private float fTime = 0.0f;

    void Start()
    {
        Direction = GetDirection();

        Speed = 5.0f;
    }

    void Update()
    {
        if(Moving)
        {
            transform.Translate(Direction * Speed * Time.deltaTime);

        }
        else
        {
            fTime = 5.0f;

            StartCoroutine("Behaviour");
        }
    }

    Vector3 GetDirection()
    {
        Moving = true;
        Vector3 Node = WayPointManager.GetInstance().TargetPoint;

        Vector3 Result = (Node - transform.position).normalized;

        Result = new Vector3(
            Node.x - transform.position.x,
            0.0f,
            Node.z - transform.position.z);

        return Result.normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Node")
        {
            int NodeNumber = WayPointManager.GetInstance().NodeNumber;

            ++NodeNumber;
            Moving = false;

            if(NodeNumber < 2)
            {

            }
            WayPointManager.GetInstance().NodeNumber = NodeNumber;
        }
    }

    IEnumerator Behaviour()
    {
        yield return new WaitForSeconds(fTime);
        Direction = GetDirection();
        transform.LookAt(Direction);

    }
}
