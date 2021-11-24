using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCoroutine : MonoBehaviour
{
    public float fTime = 0;

    private void Start()
    {
        StartCoroutine("Test"); 
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(fTime); //fTime 후에 실행하도록 한다
    
        Destroy(this);
    }
}
