using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCurser : MonoBehaviour
{
    Vector2 MousePos;

    void Update()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = MousePos;
    }
}
