using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaketMoving : MonoBehaviour
{
    private float Hor;
    private float Ver;
    [SerializeField]private float Speed;
    [SerializeField]private int WeaponeNum;
    private GameObject Mouse;

    float angle;
    Vector2 target, mouse;

    void Start()
    {
        target = transform.position;
        Speed = 0.1f;
    }

    void Update()
    {
        Mouse = GameObject.Find("MouseCursor");
        
        if(Input.GetKey(KeyCode.W))
        {
            
        }

        angle = Mathf.Atan2(Mouse.transform.position.y - target.y, Mouse.transform.position.x - target.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
