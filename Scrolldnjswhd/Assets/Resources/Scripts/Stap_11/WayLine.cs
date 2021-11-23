using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WayPoint))]
public class WayLine : Editor
{
    private void OnSceneGUI()
    {
        WayPoint t = (WayPoint)target;

        Handles.color = Color.green;

        for(int i = 0;i<t.WayPointList.Count - 1;++i)
            Handles.DrawLine(t.WayPointList[i].transform.position, t.WayPointList[i + 1].transform.position);

        Handles.DrawLine(t.WayPointList[t.WayPointList.Count-1].transform.position, t.WayPointList[0].transform.position);
    }
}
