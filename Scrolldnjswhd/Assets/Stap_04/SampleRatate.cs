using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleRatate : MonoBehaviour
{

    void Update()
    {
        //Vector.up = 기준측을 나타내는 Vector
        //Vector.up를 기준으로 0.5f의 속도만큼 회전시킴
        //this.transform.Rotate(Vector3.up,0.5f);

        //Vector(x,y,z)를 기준으로 회전(x,y,z를 직접 작성함)
        //this.transform.Rotate(0.0f, Time.deltaTime, 0.0f);

        //Space.Self = 로컬좌표를 기준으로 회전
        //Space.World = 글로벌좌표를 기준으로 회전
        //this.transform.Rotate(0.0f, Time.deltaTime * 5.0f, 0.0f,Space.Self);
        //this.transform.Rotate(0.0f, Time.deltaTime * 5.0f, 0.0f,Space.World);

        //키입력을 받아 회전시키는 코드를 작성해 보자
        float Hor = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0.0f, Hor * Time.deltaTime * 20.0f, 0.0f);
    }
}
