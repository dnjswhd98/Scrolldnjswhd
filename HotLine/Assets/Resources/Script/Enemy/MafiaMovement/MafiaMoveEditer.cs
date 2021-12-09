using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MafiaMove))]
public class MafiaMoveEditer : Editor
{
    private void OnSceneGUI()
    {
        MafiaMove va = (MafiaMove)target;

        //���� �þ߰� �ִ�ġ
        Vector3 LeftViewAngle = va.LocalViewAngle(-va.Angle / 2.0f);
        //���� �þ߰� �ִ�ġ
        Vector3 RightViewAngle = va.LocalViewAngle(va.Angle / 2.0f);

        Handles.DrawLine(va.transform.position, va.transform.position + LeftViewAngle * va.Radius);
        Handles.DrawLine(va.transform.position, va.transform.position + RightViewAngle * va.Radius);
    }
}
