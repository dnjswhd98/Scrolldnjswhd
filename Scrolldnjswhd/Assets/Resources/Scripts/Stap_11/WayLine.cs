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
        for(int i = 0;i < t.WayPointList.Count;++i)
        {
            
        }
    }
}
