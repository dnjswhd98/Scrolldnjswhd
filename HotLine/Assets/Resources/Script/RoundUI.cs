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
        if (Player.transform.Find("JaketTop").GetComponent<JaketTop>().WeaponNum >= 7)
        {
            RoundText.text = Player.transform.Find("JaketTop").GetComponent<JaketTop>().Round + " / "
                            + Player.transform.Find("JaketTop").GetComponent<JaketTop>().MaxRound + " rnds";
            if (Player.transform.Find("JaketTop").GetComponent<JaketTop>().GetNewWeapon)
            {
                Vector3 temp = new Vector3(200.0f, 50.0f, 0.0f);
                transform.parent.transform.position = temp;
            }
        }
        else
        {
            Vector3 temp = new Vector3(200.0f, -50.0f, 0.0f);
            transform.parent.transform.position = temp;
        }
    }
}
