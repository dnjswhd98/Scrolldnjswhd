using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private NavMeshAgent Agent;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit Hit;
            if(Physics.Raycast(ray, out Hit, Mathf.Infinity))
            {
                if(Hit.transform.tag == "Graund")
                {
                    Agent.Move(Hit.point);
                }
            }
        }
    }
}
