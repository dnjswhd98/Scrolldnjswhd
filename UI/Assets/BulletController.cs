using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private GameObject Prefab;
    void Start()
    {
        Prefab = Resources.Load("CFX_Explosion_B_Smoke+Text") as GameObject;
        Invoke("DestroyBullet", 2.0f);
    }

    void DestroyBullet()
    {
        Destroy(this.transform.gameObject);

        GameObject obj = Instantiate(Prefab);
        obj.transform.position = this.transform.position;

        Destroy(obj, 2.0f);
    }
}
