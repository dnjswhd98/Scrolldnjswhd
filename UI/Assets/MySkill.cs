using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySkill : MonoBehaviour
{
    private GameObject Player;
    private GameObject Graund;
    [SerializeField]private GameObject BulletPrefab;

    private void Awake()
    {
        Player = GameObject.Find("Player");
        Graund = GameObject.Find("Plane");
    }

    public void GetSkill1()
    {
        GameObject obj = Instantiate(BulletPrefab);

        obj.transform.position = new Vector3(
            Graund.transform.position.x - Random.Range(-20, 20),
            0.5f,
            Graund.transform.position.z - Random.Range(-20, 20));
    }
}
