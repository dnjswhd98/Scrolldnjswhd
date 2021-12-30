using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anim : MonoBehaviour
{
    private Animator Anime;

    private bool Skill;
    private bool atkMode;
    private bool Combineaion;

    private float SkillTime;
    private float CombineaionTime;
    private int atk;

    //private Queue<bool> CombinationList = new Queue<bool>();

    private void Awake()
    {
        Anime = transform.GetComponent<Animator>();
    }

    private void Start()
    {
        Skill = false;
        atk = 0;
        SkillTime = 5.0f;

        Combineaion = false;
        CombineaionTime = 0.1f;
    }

    void Update()
    {
        var Ver = Input.GetAxis("Vertical");
        var Hor = Input.GetAxis("Horizontal");

        if(!Skill)
        {
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Skill = true;
                StartCoroutine("PlayerRun");
            }
            if (Input.GetKey(KeyCode.LeftShift))
                Ver /= 2;
        }

        if (atkMode)
        {
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                atk = 1;
                StartCoroutine("Attack");
            }
            else if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                atk = 7;
                StartCoroutine("Attack");
            }

            if (Input.GetKeyDown(KeyCode.KeypadEnter))
                atkMode = false;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
                atkMode = true;
        }

        if (atk > 0 && !Combineaion)
        {
            if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                Combineaion = true;
                StartCoroutine("SetCombination");
            }
        }
        Anime.SetFloat("Speed", Ver);
        Anime.SetFloat("Horizontal", Hor);
        Anime.SetInteger("Attack", atk);
        Anime.SetBool("AtkMode", atkMode);
        Anime.SetBool("Combo", Combineaion);
    }
    IEnumerator PlayerRun()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);

            SkillTime -= Time.deltaTime;

            if (SkillTime <= 0)
                break;
        }

        SkillTime = 5.0f;
        Skill = false;
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.1f);
        atk = 0;
    }

    IEnumerable SetCombination()
    {
        while(true)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            CombineaionTime -= Time.deltaTime;

            Combineaion = false;

            if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                Combineaion = true;
            }

            if (CombineaionTime <= 0)
            {
                
                break;
            }

        }
    }
}
