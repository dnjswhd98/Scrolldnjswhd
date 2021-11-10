using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveP : MonoBehaviour
{
    [SerializeField] private float Speed;
    private GameObject BulletParent;
    [SerializeField] private GameObject BulletPrefab = null;
    private int Count;
    void Start()
    {
        Count = 0;
        Speed = 3.0f;
        BulletParent = new GameObject("BulletParent");
    }

    void Update()
    {
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxisRaw("Vertical");

        this.transform.Translate(
            0.0f,
            0.0f,
            Ver * Speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            this.transform.Rotate(Vector3.up, Hor);

        if (Input.GetKey(KeyCode.LeftArrow))
            this.transform.Rotate(Vector3.up, Hor);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(ObjectManager.GetInstance().GetDisableList.Count == 0)
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

            //Bullet.transform.position = transform.position;

            Bullet.SetActive(true);

            ObjectManager.GetInstance().GetEnableList.Add(Bullet);
        }
    }
}
