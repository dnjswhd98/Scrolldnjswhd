using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private GameObject BulletPrefab = null;
    private GameObject BulletParent = null;
    private int Count;
    private bool jumpM;

    private void Awake()
    {
        BulletParent = new GameObject("BulletParent");
    }

    void Start()
    {
        Speed = 5.0f;
        Count = 0;
        jumpM = false;

        Rigidbody BulletRigid = BulletPrefab.GetComponent<Rigidbody>();
        BulletRigid.useGravity = false;

        SphereCollider BulletCollider = BulletPrefab.GetComponent<SphereCollider>();
        BulletCollider.isTrigger = false;
    }

    private void Update()
    {
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxisRaw("Vertical");

        transform.Translate(
            Hor * Speed * Time.deltaTime,
            0.0f,
            Ver * Speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log(SampleObjectManager.GetInstance.name);
            if (SampleObjectManager.GetInstance.GetDisableList.Count == 0)
            {
                for (int i = 0; i < 5; ++i)
                {
                    GameObject Obj = Instantiate(BulletPrefab);
                    ++Count;
                    Obj.SetActive(false);
                    SampleObjectManager.GetInstance.GetDisableList.Push(Obj);
                }
            }
            
            GameObject Bullet = SampleObjectManager.GetInstance.GetDisableList.Pop();
            
            Bullet.transform.position = transform.position;
            
            Bullet.SetActive(true);
            
            SampleObjectManager.GetInstance.GetEnableList.Add(Bullet);
        }

        if(Input.GetKeyDown(KeyCode.Z) && jumpM == false)
        {
            GetComponent<Rigidbody>().useGravity = true;

            GetComponent<Rigidbody>().AddForce(Vector3.up * 500);

            jumpM = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Graund")
        {
            GetComponent<Rigidbody>().useGravity = false;
            //GetComponent<Rigidbody>().velocity = Vector3.zero;
            jumpM = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GetComponent<Rigidbody>().useGravity = true;
        jumpM = true;
    }
}
