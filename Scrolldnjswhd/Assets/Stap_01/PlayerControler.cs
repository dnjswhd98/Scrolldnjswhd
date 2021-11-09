using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //1��°
    /*
    public Rigidbody Rigid;

    void Start() // == init
    {
        //Rigid.AddForce(Vector3.forward * 2000);
    }
    */

    //2��°
    /*
    private Rigidbody Rigid;

    private void Awake() // ������
    {
        Rigid = this.gameObject.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start() // == init
    {
        Rigid.AddForce(Vector3.forward * 2000);
    }
    */
    /*
    [SerializeField] private Rigidbody Rigid;

    private void Awake() // ������
    {
        Rigid = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start() // == init
    {
        Rigid.AddForce(Vector3.forward * 2000);
    }
    */

    //Ű�Է� ������
    [SerializeField] private float Speed = 0.0f;
    [SerializeField] private GameObject Bulletobj;

    private List<GameObject> BulletList = new List<GameObject>();

    private GameObject Bulletparent = null;

    private void Awake()
    {
        Bulletparent = new GameObject("BulletList");
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
            //Instantiate() == ����(Clone) �Լ�
            GameObject Bullet = Instantiate(Bulletobj);
            Bullet.transform.position = transform.position;

            Bullet.GetComponent<Rigidbody>().useGravity = false;

            Bullet.transform.parent = Bulletparent.transform;

            BulletList.Add(Bullet);
        }
    }
}
