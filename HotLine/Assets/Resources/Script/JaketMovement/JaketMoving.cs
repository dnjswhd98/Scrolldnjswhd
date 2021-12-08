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
    private float CameraX;
    private float CameraY;

    float angle;
    Vector2 target, mouse;

    void Start()
    {
        Speed = 0.1f;
    }

    void Update()
    {
        target = transform.position;

        Mouse = GameObject.Find("MouseCursor");
        
        if(Input.GetKey(KeyCode.W))
            transform.Translate(new Vector3(0.0f, 0.1f, 0.0f),Space.World);        
        if (Input.GetKey(KeyCode.S))
            transform.Translate(new Vector3(0.0f, -0.1f, 0.0f), Space.World);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(new Vector3(-0.1f, 0.0f, 0.0f), Space.World);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(new Vector3(0.1f, 0.0f, 0.0f), Space.World);

        angle = Mathf.Atan2(Mouse.transform.position.y - target.y, Mouse.transform.position.x - target.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Camera.main.transform.position = new Vector3(transform.position.x,transform.position.y, Camera.main.transform.position.z);
    }
}
