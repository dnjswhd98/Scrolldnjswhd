using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackController : MonoBehaviour
{
    private Vector3 mainCameraSpeed;
    private void Start()
    {
        mainCameraSpeed = Vector3.right * 0.5f;
    }
    void Update()
    {
        transform.position += mainCameraSpeed * 5.0f * Time.deltaTime;
    }
}
