using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayPoint : MonoBehaviour
{

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            //          ray가 시작되는지점         ray가 발사되는 방향
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            /*
            //Raycast(
            Vector3 origin,           시작점
            Vector3 direction,        방향
            out RaycastHit hitInfo,   감지된 대상의 정보
            float maxDistance)        최대거리

            //Raycast(
            Ray ray                   
            out RaycastHit hitInfo,   감지된 대상의 정보
            float maxDistance)        최대거리
            */
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //DrawLine(Vector3 start, Vector3 end, Color color);
                Debug.DrawLine(Camera.main.transform.position, Vector3.forward * 0.5f, Color.red, 0.2f);

                if (hit.transform.tag == "Enemy")
                    Debug.Log("Enemy" + hit.transform.name + "를 찾았습니다");
            }
        }
    }
}
