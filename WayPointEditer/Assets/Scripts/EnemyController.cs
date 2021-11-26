using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject ParentObj;
    [SerializeField] private Node TargetNode = null;
    [SerializeField] private int num;
    private bool Moving = false;

    private void Awake()
    {
        ParentObj = GameObject.Find("Parent");
    }

    private void Start()
    {
        num = ParentObj.transform.childCount;

        Rigidbody Rigid = transform.GetComponent<Rigidbody>();
        Rigid.useGravity = false;

        CapsuleCollider Coll = transform.GetComponent<CapsuleCollider>();

        Coll.center = new Vector3(0.0f, 1.0f, 0.0f);
        Coll.radius = 2.0f;

        Coll.isTrigger = true;
        StartCoroutine("NodeChecking");
    }

    private void Update()
    {
        if(Moving)
        {
            Vector3 Direaction = (TargetNode.transform.position - transform.position).normalized;

            transform.position += Direaction * 1.5f * Time.deltaTime;

            transform.LookAt(TargetNode.transform);

            Debug.DrawLine(this.transform.position, TargetNode.transform.position, Color.red);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(TargetNode && other.transform.name == ("Node" + TargetNode.transform.childCount))
        {
            TargetNode = TargetNode.NextNode;
        }
    }

    IEnumerator NodeChecking()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);

            if(ParentObj.transform.childCount > 1)
            {
                Moving = true;

                TargetNode = ParentObj.transform.GetChild(0).GetComponent<Node>();

                break;
            }
        }
    }
}
