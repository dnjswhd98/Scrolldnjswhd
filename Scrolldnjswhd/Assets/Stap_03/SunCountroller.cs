using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunCountroller : MonoBehaviour
{
     // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up, 0.5f);
    }
}
