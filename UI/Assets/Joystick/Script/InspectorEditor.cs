using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class InspectorEditor : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    /*
    [Header("Element")]
    [Tooltip("이동속도")]
    [SerializeField] private float Speed;

    [Tooltip("공격력")]
    [SerializeField] private float Att;

    [Tooltip("방어력")]
    [SerializeField] private float Def;

    [Tooltip("체력")]
    [SerializeField] private float HP;

    [Tooltip("마력")]
    [Range(0, 10)]
    [SerializeField] private float MP;
     */

    [Tooltip("움직일 대상")]
    [SerializeField] private Transform Target;

    [Tooltip("움직임을 제어할 스틱")]
    [SerializeField] private RectTransform Stick;

    [Tooltip("스틱의 뒷 배경")]
    [SerializeField] private RectTransform BackBoard;


    // ** 스틱 뒷 배경의 반지름.
    private float Radius = 0.0f;

    // ** 입력 확인.
    private bool TouchCheck = false;

    // ** 이동 속도.
    private float Speed = 0.0f;

    // ** 방향 값.
    private Vector2 Direction;

    // ** 이동 값.
    private Vector3 Movement;

    // ** 회전 값
    private Vector3 Rotation;

    private void Awake()
    {
        BackBoard = GameObject.Find("OutLineCircle").GetComponent<RectTransform>();
        Stick = GameObject.Find("FilledCircle").GetComponent<RectTransform>();
    }


    void Start()
    {
        // ** BackBoard의 반지름을 구함.
        Radius = (BackBoard.rect.width / 2.0f);
        Speed = 5.0f;
    }

    void Update()
    {
        if (TouchCheck)
        {
            Target.position += Movement;
            Target.localRotation = Quaternion.Euler(Rotation);
        }
    }

    private void GetMovement(Vector2 _Point)
    {
        Stick.localPosition = new Vector2(
            _Point.x - BackBoard.position.x,
            _Point.y - BackBoard.position.y );

        Stick.localPosition = Vector2.ClampMagnitude(
            Stick.localPosition, Radius);

        // ** 비율을 구함.   
        float Ratio = (BackBoard.position - Stick.position).sqrMagnitude / (Radius * Radius);

        Direction = Stick.localPosition.normalized;

        Movement = new Vector3(
            Direction.x * Speed * Ratio * Time.deltaTime,
            0.0f,
            Direction.y * Speed * Ratio * Time.deltaTime);

        Rotation = new Vector3(0.0f, Mathf.Atan2(Direction.x, Direction.y) * Mathf.Rad2Deg, 0.0f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        GetMovement(eventData.position);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GetMovement(eventData.position);
        TouchCheck = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Stick.localPosition = Vector3.zero;
        TouchCheck = false;
    }
}
