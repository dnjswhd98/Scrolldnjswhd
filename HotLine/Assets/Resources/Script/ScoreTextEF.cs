using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextEF : MonoBehaviour
{
    private Text uiText;
    private bool RotF;

    void Start()
    {
        uiText = GetComponent<Text>();
        RotF = false;
    }

    void Update()
    {
        if (Singleton.EnemyList.Count != 0)
            uiText.text = "Enemy " + Singleton.EnemyList.Count + " LEFT";
        else
            uiText.text = "Floor Clear!";

        if (!RotF && transform.rotation == Quaternion.Euler(0.0f, 0.0f, 9.0f))
        {

        }
        
    }
}
