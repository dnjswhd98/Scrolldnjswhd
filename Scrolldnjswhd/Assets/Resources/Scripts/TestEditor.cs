using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Test))]
public class TestEditor : Editor
{
    private void OnSceneGUI()
    {
        Test t = (Test)target;

        //DrawWireArc(Vector3 center, Vector3 normal, Vector3 from, float angle, float radius);
        Handles.DrawWireArc(
            t.transform.position,
            Vector3.up,
            Vector3.forward,
            360.0f,
            t.Radius
            );
    }
}
