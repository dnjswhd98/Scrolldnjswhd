using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float CameraSpeed;
    public Camera MainCamera;

    private void Start()
    {
        CameraSpeed = 3.0f;
    }
    void Update()
    {
        MainCamera.transform.position += Vector3.right * CameraSpeed;
    }
}
