using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject Target;

    [SerializeField] private float SmoothTime;

    [SerializeField] private Vector3 Offset;
    //public Vector3 Offset = new Vector3(0.0f, 0.0f, 0.0f);

    //ī�޶��� �ִ� ��ġ
    [SerializeField] Vector3 MaxCameraPosition;
    //�ּ�
    [SerializeField] Vector3 MinCameraPosition;

    private float Distance;

    private Vector3 Velocity;

    private float ZoomDistance;

    private Camera MainCamera;

    private Vector3 StartCameraPosition;

    private Vector3 CameraPosition;

    private bool ShakeCamera;

    [SerializeField] LayerMask PlayerMask;

    [Range(0.0f, 1.0f)]
    private float Radius;

    private void Awake()
    {
        MainCamera = GetComponent<Camera>();

        /* // Ư������� ������ �ʰ���
        PlayerMask = LayerMask.NameToLayer("Player");
        MainCamera.cullingMask = (1 << PlayerMask) - 1;
        */
    }

    void Start()
    {
        SmoothTime = 1.0f;

        Offset = new Vector3(0.0f, 5.0f, -8.0f);

        MaxCameraPosition = new Vector3(0.0f, 17.5f, -17.5f);
        MinCameraPosition = new Vector3(0.0f, -17.5f, 17.5f);

        Velocity = Vector3.zero;

        ZoomDistance = 0.0f;

        Distance = 0.5f;

        ShakeCamera = false;

        Radius = 1.0f;
    }

    void Update()
    {

        //ī�޶� ���� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShakeCamera = !ShakeCamera;
        }

        //����
        if(ShakeCamera)
        {
            Vector3 ShakeOffset = new Vector3(Random.Range(-0.1f,0.1f) * Radius, Random.Range(-0.1f, 0.1f) * Radius, 0.0f);
        
            MainCamera.transform.position += ShakeOffset;
        }
        
        //��
        MoundeWheel();

        //�� Distance�� �ּҰ�& �ִ밪�� ����
        Distance = Mathf.Clamp(Distance, 0.0f, 1.0f);

        Vector3 Direction = Target.transform.forward;

        Direction.z *= -10;
        transform.position = Direction + Target.transform.position;

        //�ִ밪�� �ּҰ� ���̿��� �ε巴�� �����̰� ��
        transform.position = Vector3.Lerp(Target.transform.position + MaxCameraPosition, Target.transform.position + MinCameraPosition, 
            Distance);

        //ī�޶� Ÿ���� �ε巴�� �ٶ󺸰���
        transform.rotation = Quaternion.Lerp(Target.transform.rotation, 
            Quaternion.LookRotation((Target.transform.position - transform.position).normalized),
            Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            Vector3 CurrentRotate = transform.rotation.eulerAngles;

            CurrentRotate.y += Input.GetAxis("Mouse X") * 5.0f;

            Quaternion CurrentQuaternion = Quaternion.Euler(CurrentRotate);

            transform.rotation = Quaternion.Slerp(transform.rotation, CurrentQuaternion, Time.deltaTime * 5.0f * SmoothTime);
        }

        //transform.position = Vector3.SmoothDamp(transform.position, Offset + Target.transform.position, ref Velocity, SmoothTime);
    }

    void MoundeWheel()
    {
        float Wheel = Input.GetAxis("Mouse ScrollWheel") * -1;

        if(Wheel != 0)
        {
            Distance += Wheel * Time.deltaTime;
        }

        Distance = Mathf.Lerp(Distance, Wheel * 10.0f * Time.deltaTime, Time.deltaTime);

        transform.position = Vector3.Lerp(Target.transform.position + MaxCameraPosition, Target.transform.position + MinCameraPosition, Distance);

        /*
        ZoomDistance += Wheel * 10.0f;

        if (ZoomDistance < 20.0f)
            ZoomDistance = 20.0f;
        if (ZoomDistance > 60.0f)
            ZoomDistance = 60.0f;

        MainCamera.fieldOfView = Mathf.Lerp(
            MainCamera.fieldOfView, ZoomDistance, Time.deltaTime * 5.0f);
        */
    }
}
