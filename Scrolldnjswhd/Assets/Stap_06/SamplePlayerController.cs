using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float Speed = 0.0f;
    //생성된 Bullet복제본의 BulletParent 하위로 생성하기 위함
    private GameObject BulletParent = null;
    //Bullet의 객체원형
    [SerializeField] private GameObject BulletPrefab = null;
    private int Count;

    private void Awake()
    {
        BulletParent = new GameObject("BulletParent");
        //BulletPrefab = Resources.Load("Stap_01/Bullet") as GameObject;
        
    }

    private void Start()
    {
        Speed = 5.0f;
        Count = 0;

        Rigidbody BulletRigid = BulletPrefab.GetComponent<Rigidbody>();
        BulletRigid.useGravity = false;
        
        SphereCollider BulletCollider = BulletPrefab.GetComponent<SphereCollider>();
        BulletCollider.isTrigger = false;
    }

    void Update()
    {
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxisRaw("Vertical");

        this.transform.Translate(
            Hor * Speed * Time.deltaTime,
            0.0f,
            Ver * Speed * Time.deltaTime
            );

        //if(Input.GetKey(KeyCode.RightArrow))
        //{
        //    this.transform.Rotate(Vector3.up, Hor);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    this.transform.Rotate(Vector3.up, Hor);
        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ObjectManager.GetInstance().GetDisableList.Count == 0)
            {
                for (int i = 0; i < 5; ++i)
                {
                    GameObject Obj = Instantiate(BulletPrefab);
                    ++Count;
                    Obj.SetActive(false);

                    ObjectManager.GetInstance().GetDisableList.Push(Obj);
                }
            }

            GameObject Bullet = ObjectManager.GetInstance().GetDisableList.Pop();

            Bullet.transform.position = transform.position;

            Bullet.SetActive(true);

            ObjectManager.GetInstance().GetEnableList.Add(Bullet);
        }
    }
}
