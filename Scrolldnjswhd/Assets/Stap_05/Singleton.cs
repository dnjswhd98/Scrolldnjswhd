using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    //ΩÃ±€≈Ê1
    //private static Singleton Instance = null;
    //public static Singleton GetInstance()
    //{
    //    if (Instance == null)
    //        Instance = new Singleton();
    //
    //    return Instance;
    //}
    //
    //public void Output()
    //{
    //    Debug.Log("Singleton");
    //}

    //2
    //private static Singleton Instance = null;
    //public static Singleton GetInstance
    //{
    //    get
    //    {
    //        if (Instance == null)
    //            Instance = new Singleton();
    //
    //        return Instance;
    //    }
    //}

    //3
    private static Singleton Instance = null;
    private static GameObject Container = null;
 
    public static Singleton GetInstance()
    {
        if (Instance == null)
        {
            Container = new GameObject("Singleton");
            Instance = new Singleton();

            Instance = Container.AddComponent(typeof(Singleton)) as Singleton;
        }
        return Instance;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Singleton");
        }
    }
    public void Output()
    {
        Debug.Log("Singleton");
    }
}
