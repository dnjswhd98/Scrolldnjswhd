using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContriollor : MonoBehaviour
{
    public Camera MinimapCamera;
    [SerializeField] [Range(0.01f, 0.1f)] float ShakeRadius;
    [SerializeField] [Range(0.01f, 0.1f)] float ShakeTime;
    [SerializeField] [Range(0.0f, 0.1f)] float ZoomDiatance;

    public GameObject Target;

    private void Awake()
    {
        MinimapCamera = GetComponent<Camera>();
    }

    private void Start()
    {
        this.transform.position = new Vector3(0.0f, 45.0f, 0.0f);

        ShakeTime = 0.5f;
        ShakeRadius = 0.1f;
        ZoomDiatance = 0.0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            InvokeRepeating("StartShake", 0f, 0.01f);

        if (Input.GetKeyDown(KeyCode.S))
            Invoke("StopShaking", 0.0f);

        MouseWheel();

        CameraHorizontal();

        MinimapCamera.fieldOfView = Mathf.Lerp(MinimapCamera.fieldOfView, ZoomDiatance, Time.deltaTime * 4);

        MinimapCamera.transform.position = Target.transform.position - Vector3.forward + Vector3.up * 20.0f;
    }

    private void MouseWheel()
    {
        float ScrollWheel = Input.GetAxis("Mouse ScrollWheel") * -1;

        ZoomDiatance += (ScrollWheel * 10);

        if (ZoomDiatance > 20f)
            ZoomDiatance = 20f;
        if (ZoomDiatance < 60f)
            ZoomDiatance = 60f;
    }

    private void CameraHorizontal()
    {
        if(Input.GetMouseButton(1))
        {

            Vector3 CurrentRotate = transform.rotation.eulerAngles;

            CurrentRotate.y += Input.GetAxis("Mouse.X") * 5;

            Quaternion CurrentQuaternion = Quaternion.Euler(CurrentRotate);

            CurrentQuaternion.z = 0;
        }
    }

    void StartShake()
    {
        Vector3 CameraPos = new Vector3(Random.value * ShakeRadius, Random.value * ShakeRadius);

        Vector3 CurrentCamera = new Vector3(
            this.transform.position.x + CameraPos.x,
            this.transform.position.y + CameraPos.y,
            this.transform.position.z);

        //MinimapCamera.transform.position = CurrentCamera;
    }

    void StopShake()
    {
        CancelInvoke("StartShake");

        //MinimapCamera
    }
}
