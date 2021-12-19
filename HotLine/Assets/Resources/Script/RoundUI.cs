using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundUI : MonoBehaviour
{
    GameObject Player;
    Text RoundText;

    void Start()
    {
        RoundText = GetComponent<Text>();
    }

    void Update()
    {
        Player = GameObject.Find("Jaket(Clone)");
        RoundText.text = Player.transform.Find("JaketTop").GetComponent<JaketTop>().Round + " / "
                        + Player.transform.Find("JaketTop").GetComponent<JaketTop>().MaxRound + " rnds";
    }
}
