using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject Target;

    [SerializeField] private float SmoothTime;

    [SerializeField] private Vector3 Offset;
    //public Vector3 Offset = new Vector3(0.0f, 0.0f, 0.0f);

    private Vector3 Velocity;

    private float ZoomDistance;

    private Camera MainCamera;

    private Vector3 StartCameraPosition;

    private Vector3 CameraPosition;

    private bool ShakeCamera;

    [Range(0.0f, 1.0f)]
    private float Radius;

    private void Awake()
    {
        MainCamera = GetComponent<Camera>();

    }

    void Start()
    {
        SmoothTime = 1.0f;

        Offset = new Vector3(0.0f, 5.0f, -8.0f);

        Velocity = Vector3.zero;

        ZoomDistance = 0.0f;

        ShakeCamera = false;

        Radius = 1.0f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ShakeCamera = !ShakeCamera;
        }

        if(ShakeCamera)
        {
            Vector3 ShakeOffset = new Vector3(Random.value * Radius, Random.value * Radius, 0.0f);



            MainCamera.transform.position = ShakeOffset;
        }

        MoundeWheel();

        if (Input.GetMouseButton(0))
        {
            Vector3 CurrentRotate = transform.rotation.eulerAngles;

            CurrentRotate.y += Input.GetAxis("Mouse X") * 5.0f;

            Quaternion CurrentQuaternion = Quaternion.Euler(CurrentRotate);

            transform.rotation = Quaternion.Slerp(transform.rotation, CurrentQuaternion, Time.deltaTime * 5.0f * SmoothTime);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.LookRotation(Target.transform.position - transform.position).normalized,
                Time.deltaTime * 5.0f * SmoothTime);
        }

        transform.position = Vector3.SmoothDamp(transform.position, Offset + Target.transform.position, ref Velocity, SmoothTime);
    }

    void MoundeWheel()
    {
        float Wheel = Input.GetAxis("Mouse ScrollWheel");

        ZoomDistance += Wheel * 10.0f;

        if (ZoomDistance < 20.0f)
            ZoomDistance = 20.0f;
        if (ZoomDistance > 60.0f)
            ZoomDistance = 60.0f;

        MainCamera.fieldOfView = Mathf.Lerp(
            MainCamera.fieldOfView, ZoomDistance, Time.deltaTime * 5.0f);
    }
}
