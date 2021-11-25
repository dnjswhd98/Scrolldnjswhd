using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMove : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private Vector3 Direction;
    [SerializeField] private GameObject Target;
    private int num;

    void Start()
    {
        Speed = 5.0f;
        num = 0;
        Target = GameObject.Find("Node " + num);
    }

    void Update()
    {
        Direction = Target.transform.position.normalized;
        transform.Translate(Direction * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Target")
        {
            Debug.Log("adas");
            GameObject.Find("Node " + num);
        }
    }
}
