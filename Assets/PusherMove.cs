using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PusherMove : MonoBehaviour
{
    //初期地点
    Vector3 initPos;

    //新しい地点
    Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        //初期地点に今の座標を入れる
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