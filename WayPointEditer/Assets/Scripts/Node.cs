using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Node : MonoBehaviour
{
    public Node NextNode;
    public int Index;

    private void Start()
    {
        transform.tag = "Node";

        SphereCollider Coll = transform.GetComponent<SphereCollider>();
        Coll.isTrigger = true;
        Rigidbody Rigid = transform.GetComponent<Rigidbody>();
        Rigid.useGravity = false;

        Coll.radius = 0.2f;
    }
}

[CustomEditor(typeof(Node))]
public class NodeEditor : Editor
{
    private void OnSceneGUI()
    {
        Node t = (Node)target;

        Handles.color = Color.white;

        Handles.DrawLine(t.transform.position, t.NextNode.transform.position);
    }
}
