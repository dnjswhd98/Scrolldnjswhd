using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextEF : MonoBehaviour
{
    private Text uiText;
    private int Count;
    private bool RotF;
    private Vector3 rot; 

    void Start()
    {
        uiText = GetComponent<Text>();
        RotF = false;
        rot = new Vector3(0.0f, 0.0f, 0.02f);
        Count = 0;
    }

    void Update()
    {
        if (!GameObject.FindWithTag("player").GetComponent<JaketMoving>().Dead)
        {
            if (Singleton.EnemyList.Count != 0)
                uiText.text = "Enemy " + Singleton.EnemyList.Count + " LEFT";
            else
                uiText.text = "Floor Clear!";
        }
        else
            uiText.text = "YOU'RE DEAD!";
        //if (!RotF)
        //{
        //    uiText.transform.Rotate(rot);
        //    rot.z -= 0.001f;
        //
        //    if (uiText.transform.rotation == Quaternion.Euler(0.0f, 0.0f, 9.0f))
        //    {
        //        RotF = true;
        //        rot.z = 0.02f;
        //    }
        //}
        //else
        //{
        //    uiText.transform.Rotate(-rot);
        //    rot.z -= 0.001f;
        //
        //    if (uiText.transform.rotation == Quaternion.Euler(0.0f, 0.0f, -9.0f))
        //    {
        //        RotF = false;
        //        rot.z = 0.02f;
        //    }
        //}
    }
}
