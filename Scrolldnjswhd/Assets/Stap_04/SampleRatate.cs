using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleRatate : MonoBehaviour
{

    void Update()
    {
        //Vector.up = �������� ��Ÿ���� Vector
        //Vector.up�� �������� 0.5f�� �ӵ���ŭ ȸ����Ŵ
        //this.transform.Rotate(Vector3.up,0.5f);

        //Vector(x,y,z)�� �������� ȸ��(x,y,z�� ���� �ۼ���)
        //this.transform.Rotate(0.0f, Time.deltaTime, 0.0f);

        //Space.Self = ������ǥ�� �������� ȸ��
        //Space.World = �۷ι���ǥ�� �������� ȸ��
        //this.transform.Rotate(0.0f, Time.deltaTime * 5.0f, 0.0f,Space.Self);
        //this.transform.Rotate(0.0f, Time.deltaTime * 5.0f, 0.0f,Space.World);

        //Ű�Է��� �޾� ȸ����Ű�� �ڵ带 �ۼ��� ����
        float Hor = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0.0f, Hor * Time.deltaTime * 20.0f, 0.0f);
    }
}
