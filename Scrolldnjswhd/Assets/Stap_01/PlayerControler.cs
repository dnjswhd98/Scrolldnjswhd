using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //1번째
    /*
    public Rigidbody Rigid;

    void Start() // == init
    {
        //Rigid.AddForce(Vector3.forward * 2000);
    }
    */

    //2번째
    /*
    private Rigidbody Rigid;

    private void Awake() // 생성자
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

    private void Awake() // 생성자
    {
        Rigid = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start() // == init
    {
        Rigid.AddForce(Vector3.forward * 2000);
    }
    */

    //키입력 움직임
    [SerializeField] private float Speed = 0.0f;
    [SerializeField] private GameObject Bulletobj;

    private List<GameObject> BulletList = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxisRaw("Vertical");

        this.transform.Translate(
            Hor * Speed * Time.deltaTime,
            0.0f,
            Ver * Speed * Time.deltaTime
            );

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.Rotation(Vector3.up);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate() == 복제(Clone) 함수
            GameObject Bullet = Instantiate(Bulletobj);
            Bullet.transform.position = transform.position;

            Bullet.GetComponent<Rigidbody>().useGravity = false;

            BulletList.Add(Bullet);
        }
    }
}
