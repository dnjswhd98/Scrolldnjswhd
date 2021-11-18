using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ViewAngle))]
public class ViewAngleEditor : Editor
{
    private void OnSceneGUI()
    {
        ViewAngle va = (ViewAngle)target;

        //DrawWireArc(Vector3 center, Vector3 normal, Vector3 from, float angle, float radius);
        Handles.DrawWireArc(va.transform.position, Vector3.up, Vector3.forward, 360.0f, va.Radius);

        //촤측 시야각 최대치
        Vector3 LeftViewAngle = va.LocalViewAngle(-va.Angle / 2.0f);
        //우측 시야각 최대치
        Vector3 RightViewAngle = va.LocalViewAngle(va.Angle / 2.0f);

        //Vector3 TAngle = va.LocalViewAngle(va.transform.rotation.y);

        Handles.DrawLine(va.transform.position, va.transform.position + LeftViewAngle * va.Radius);
        Handles.DrawLine(va.transform.position, va.transform.position + RightViewAngle * va.Radius);

        Handles.color = Color.green;
        for (int i = 0; i < va.TargetList.Count; ++i)
        {
            //DrawLine(Vector3 p1, Vector3 p2);
            Handles.DrawLine(va.transform.position, va.TargetList[i].position);
        }
    }


  
}
