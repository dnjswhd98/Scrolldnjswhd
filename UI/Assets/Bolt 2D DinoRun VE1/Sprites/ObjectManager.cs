using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(Physics2D.Raycast(this.transform.position, Vector2.up))
        {
            Debug.Log("asdf");
        }
    }
}
