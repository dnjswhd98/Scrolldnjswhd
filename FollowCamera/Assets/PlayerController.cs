using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    void Update()
    {
        var Hor = Input.GetAxis("Horizontal");

        transform.RotateAround(this.transform.position, Vector3.up, Hor * Time.deltaTime * 50.0f);
    }
}
