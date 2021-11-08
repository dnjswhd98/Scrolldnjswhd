using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleSingletonTest : MonoBehaviour
{
    private void Awake()
    {
        //3
        Singleton.GetInstance();
    }
    //void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Return))
    //    {
    //        //ΩÃ±€≈Ê1
    //        //Singleton.GetInstance().Output();
    //
    //        //2
    //        //Singleton.GetInstance.Output();
    //    }
    //}
}
