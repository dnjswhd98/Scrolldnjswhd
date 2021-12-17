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
        //if (Player.transform.Find("JaketTop").GetComponent<JaketTop>().WeaponNum >= 7)
        //{
        //    RoundText.text = Player.transform.Find("JaketTop").GetComponent<JaketTop>().Round + " / "
        //                + Player.transform.Find("JaketTop").GetComponent<JaketTop>().MaxRound + " rnds";
        //    //switch(Player.transform.Find("JaketTop").GetComponent<JaketTop>().WeaponNum)
        //    //{
        //    //    case 7:
        //    //        
        //    //        break;
        //    //    default:
        //    //        break;
        //    //}
        //}
    }
}
