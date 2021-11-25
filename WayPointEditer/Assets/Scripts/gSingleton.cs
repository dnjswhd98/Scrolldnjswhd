using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gSingleton : MonoBehaviour
{
    private static gSingleton Instance = null;
    public static gSingleton GetInstance()
    {
        if(Instance == null)
            Instance = new gSingleton();

        return Instance;
    }

    public Vector3 NodePos;
    public List<GameObject> NodeList = new List<GameObject>();
}
