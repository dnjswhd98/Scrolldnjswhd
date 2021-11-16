using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InsfacterAddAdeter : MonoBehaviour,IDragHandler, IPointerUpHandler,IPointerDownHandler
{
    /*
    [Header("Element")]
    [Tooltip("�̵��ӵ�")]
    [SerializeField] private float Speed;

    [Tooltip("���ݷ�")]
    [SerializeField] private float Atk;

    [Tooltip("����")]
    [SerializeField] private float Def;

    [Tooltip("ü��")]
    [SerializeField] private float Hp;

    [Tooltip("����")]
    [Range(0,10)]
    [SerializeField] private float Mp;
    */

    [Tooltip("������ ���")]
    [SerializeField] private Transform Target;
    [Tooltip("�������� ������ ��ƽ")]
    [SerializeField] private RectTransform Stick;
    [Tooltip("��ƽ�� �� ���")]
    [SerializeField] private RectTransform BackBoard;

    //�޹���� ������
    private float Radius = 0.0f;
    //�Է� Ȯ��
    private bool TouchCheck = false;
    //�̵��ӵ�
    private float Speed = 0.0f;
    //���Ⱚ
    private Vector2 Direction;
    //�̵���
    private Vector3 Movement;

    void Start()
    {
        //BackBoard�� �������� ����
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

        //��ƽ�� �麸�带 ����� �ʵ��� ���ش�
        Stick.localPosition = Vector2.ClampMagnitude(Stick.localPosition, Radius);

        //������ ����
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
