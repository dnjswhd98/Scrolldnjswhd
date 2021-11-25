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
        GameObject NodeObj = new GameObject("Node " + PerentNode.transform.childCount);
        NodeObj.gameObject.tag = "Target";
        NodeObj.transform.parent = PerentNode.transform;

        NodeObj.AddComponent<GetGizmo>();
        NodeObj.AddComponent<Node>();
        NodeObj.AddComponent<SphereCollider>();

        NodeObj.transform.position = new Vector3(Random.Range(-5.0f, 5.0f), 0.0f, Random.Range(-5.0f, 5.0f));
        gSingleton.GetInstance().NodePos = NodeObj.transform.position;

        Node node = NodeObj.GetComponent<Node>();
        gSingleton.GetInstance().NodeList.Add(NodeObj);

        if(PerentNode.transform.childCount > 1)
        {
            node.NextNode = PerentNode.transform.GetChild(PerentNode.transform.childCount - 2).GetComponent<Node>();

            GameObject FirstObject = GameObject.Find("Node" + 0);

            Node FirstNode = FirstObject.GetComponent<Node>();
            FirstNode.NextNode = node;
        }
    }
}
