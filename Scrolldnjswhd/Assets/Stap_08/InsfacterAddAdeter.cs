using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InsfacterAddAdeter : MonoBehaviour,IDragHandler, IPointerUpHandler,IPointerDownHandler
{
    /*
    [Header("Element")]
    [Tooltip("이동속도")]
    [SerializeField] private float Speed;

    [Tooltip("공격력")]
    [SerializeField] private float Atk;

    [Tooltip("방어력")]
    [SerializeField] private float Def;

    [Tooltip("체력")]
    [SerializeField] private float Hp;

    [Tooltip("마나")]
    [Range(0,10)]
    [SerializeField] private float Mp;
    */

    [Tooltip("움직일 대상")]
    [SerializeField] private Transform Target;
    [Tooltip("움직임을 제어할 스틱")]
    [SerializeField] private RectTransform Stick;
    [Tooltip("스틱의 뒷 배경")]
    [SerializeField] private RectTransform BackBoard;

    //뒷배경의 반지름
    private float Radius = 0.0f;
    //입력 확인
    private bool TouchCheck = false;
    //이동속도
    private float Speed = 0.0f;
    //방향값
    private Vector2 Direction;
    //이동값
    private Vector3 Movement;

    void Start()
    {
        //BackBoard의 반지름을 구함
        Radius = BackBoard.rect.width / 2.0f;

        Speed = 5.0f;
    }

    void Update()
    {
        if (TouchCheck)
            Target.position += Movement;
    }

    private void GetMovemect(Vector2 _Point)
    {
        Stick.localPosition = new Vector2(
            _Point.x - BackBoard.position.x,
            _Point.y - BackBoard.position.y);

        //스틱이 백보드를 벗어나지 않도록 해준다
        Stick.localPosition = Vector2.ClampMagnitude(Stick.localPosition, Radius);

        //비율을 구함
        float Ratio = (BackBoard.position - Stick.position).sqrMagnitude / (Radius * Radius);

        Direction = Stick.localPosition.normalized;

        Movement = new Vector3(
            Direction.x * Speed * Ratio * Time.deltaTime,
            0,
            Direction.y * Speed * Ratio * Time.deltaTime);
    }

    public void OnDrag(PointerEventData eventData)
    {
        GetMovemect(eventData.position);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GetMovemect(eventData.position);
        TouchCheck = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Stick.localPosition = Vector3.zero;
        TouchCheck = false;
    }
}
