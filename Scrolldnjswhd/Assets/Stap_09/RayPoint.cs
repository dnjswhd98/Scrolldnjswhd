using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayPoint : MonoBehaviour
{
    public GameObject MainCamera;
    [SerializeField]private GameObject Cubeprefab;

    private void Awake()
    {
        MainCamera = GameObject.Find("Main Camera");
        Cubeprefab = Resources.Load("Prefabs/Cube") as GameObject;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            //          ray�� ���۵Ǵ�����         ray�� �߻�Ǵ� ����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            /*
            //Raycast(
            Vector3 origin,           ������
            Vector3 direction,        ����
            out RaycastHit hitInfo,   ������ ����� ����
            float maxDistance)        �ִ�Ÿ�

            //Raycast(
            Ray ray                   
            out RaycastHit hitInfo,   ������ ����� ����
            float maxDistance)        �ִ�Ÿ�
            */
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //DrawLine(Vector3 start, Vector3 end, Color color);
                //Debug.DrawLine(Camera.main.transform.position, Vector3.forward * 0.5f, Color.red, 0.2f);

                //if (hit.transform.tag == "Enemy")
                //    Debug.Log("Enemy" + hit.transform.name + "�� ã�ҽ��ϴ�");

                GameObject Obj = Instantiate(Cubeprefab);
                Obj.transform.position = hit.point;
            }
        }
    }
}
