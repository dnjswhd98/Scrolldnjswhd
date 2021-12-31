using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]private GameObject Target;
    [SerializeField]private NavMeshAgent Agent;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Target = GameObject.Find("Player");
    }

    void Update()
    {
        var Distance = Vector3.Distance(transform.position, Target.transform.position);

        var Direction = (transform.position - Target.transform.position).normalized;

        //LookRotation = Vector를 Quaternion으로 변환        

        if (Distance <= 15)
        {
            Agent.SetDestination(Target.transform.position);
        }
        else
        {
            Agent.enabled = false;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Direction), Time.deltaTime);

            Agent.enabled = true;
        }
    }
}
