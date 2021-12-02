using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackController : MonoBehaviour
{
    private Vector3 mainCameraSpeed;
    DinoCon dinbo;
    private void Start()
    {
        dinbo = new DinoCon();
        mainCameraSpeed = Vector3.right * 0.5f;
    }
    void Update()
    {
        if(!dinbo.getDead())
            transform.position += mainCameraSpeed * 9.0f * Time.deltaTime;
    }
}
