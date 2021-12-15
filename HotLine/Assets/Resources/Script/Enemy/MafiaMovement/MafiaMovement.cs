using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MafiaMovement : MonoBehaviour
{
    public bool FindPlayer;
    private bool Move;
    private bool EnemyAttack;
    private int WeaponNum;
    private float angle;

    private Vector2 target;

    private GameObject Player;

    void Start()
    {
        FindPlayer = false;
        Move = false;
        EnemyAttack = false;
    }

    void Update()
    {
        target = transform.position;
        Player = GameObject.Find("Jaket(Clone)");

        if(FindPlayer)
        {
            angle = Mathf.Atan2(Player.transform.position.y - target.y, Player.transform.position.x - target.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
