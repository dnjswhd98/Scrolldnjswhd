using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WayPointEditor : EditorWindow
{
    [MenuItem("Tools/WayPoint Editor")]
    static public void Initalize()
    {
        WayPointEditor Window = GetWindow<WayPointEditor>();
        Window.Show();
    }

    [Tooltip("")]
    public GameObject PerentNode = null;

    private void OnGUI()
    {
        SerializedObject Obj = new SerializedObject(this);

        EditorGUILayout.PropertyField(Obj.FindProperty("PerentNode"));
        if(PerentNode == null)
        {
            EditorGUILayout.HelpBox("root node 없음",MessageType.Warning);    //root node == 최상위 노드
        }
        else
        {
            //GUILayout.Width(), GUILayout.Height();
            EditorGUILayout.BeginVertical();
            if(GUILayout.Button("CreateNode"))
            {
                CreateNode();
            }
            EditorGUILayout.EndVertical();

        }

        //현재 위 코드의 내용을 적용시킴
        Obj.ApplyModifiedProperties();
    }

    public void CreateNode()
    {
        while (true)
        {
            GameObject NodeObj = new GameObject("Node " + PerentNode.transform.childCount);
            NodeObj.transform.parent = PerentNode.transform;

            NodeObj.AddComponent<GetGizmo>();
            NodeObj.AddComponent<SphereCollider>();
            NodeObj.AddComponent<Rigidbody>();
            Node CurrentNode = NodeObj.AddComponent<Node>();

            CurrentNode.Index = PerentNode.transform.childCount;

            NodeObj.transform.position = new Vector3(Random.Range(-20.0f, 20.0f), 1.0f, Random.Range(-20.0f, 20.0f));

            float Distance = 1000.0f;

            Node node = NodeObj.GetComponent<Node>();
            gSingleton.GetInstance().NodeList.Add(NodeObj);

            if (PerentNode.transform.childCount > 1)
            {
                Node PreviousNode = PerentNode.transform.GetChild(PerentNode.transform.childCount - 2).GetComponent<Node>();

                PreviousNode.NextNode = PerentNode.transform.GetChild(PerentNode.transform.childCount - 1).GetComponent<Node>();

                CurrentNode.NextNode = PerentNode.transform.GetChild(0).GetComponent<Node>();

                Distance = Vector3.Distance(PreviousNode.transform.position, CurrentNode.transform.position);
            }

            if (Distance > 1.5f)
                break;
        }
    }
}
