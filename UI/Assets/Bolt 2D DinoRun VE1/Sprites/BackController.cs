using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackController : MonoBehaviour
{
    private Vector3 mainCameraSpeed;
    [SerializeField]private GameObject target;
    private Vector3 StartPosition;

    private void Start()
    {
        //GameOver = false;
        mainCameraSpeed = Vector3.right * 0.5f;
        StartPosition = transform.position;
    }
    void Update()
    {
        if (!DinoCon.dead)
            transform.position += mainCameraSpeed * 9.0f * Time.deltaTime;
        else
            target.active = true;
    }

    public void ReStart()
    {
        transform.position = StartPosition;
        DinoCon.dead = false;
        target.active = false;
        DinoCon.rigid2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
