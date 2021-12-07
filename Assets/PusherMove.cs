using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PusherMove : MonoBehaviour
{
    //�����n�_
    Vector3 initPos;

    //�V�����n�_
    Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        //�����n�_�ɍ��̍��W������
        initPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        newPos = new Vector3(
            initPos.x,
            initPos.y,
            initPos.z + Mathf.Sin(Time.time)
            );
        this.GetComponent<Rigidbody>().MovePosition(newPos);
    }
}