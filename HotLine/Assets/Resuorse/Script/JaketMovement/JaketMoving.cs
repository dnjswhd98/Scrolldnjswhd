using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaketMoving : MonoBehaviour
{
    private float Hor;
    private float Ver;
    [SerializeField] float Speed;

    float angle;
    Vector2 target, mouse;

    void Start()
    {
        target = transform.position;
        Speed = 0.1f;
    }

    void Update()
    {
        Hor = Input.GetAxis("Horizontal");
        Ver = Input.GetAxis("Vertical");
        transform.Translate(Hor*Speed, Ver*Speed, 0.0f);

        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
