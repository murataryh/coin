using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    //ç∂ÇÃï«
    public GameObject leftWall;

    //âEÇÃï«
    public GameObject rightWall;

    public GameObject Coin;

    float leftWallPositionX;
    float rightWallPositionX;
    public float moveSpeed = 2.0f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        leftWallPositionX =
            leftWall.transform.position.x +
            leftWall.transform.localScale.x / 2 +
            this.transform.localScale.x / 2;
        rightWallPositionX =
            rightWall.transform.position.x -
            rightWall.transform.localScale.x / 2 -
            this.transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(x, 0, 0);

        rb.velocity = direction * moveSpeed;

        Vector3 currentPosition = this.transform.position;

        currentPosition.x =
            Mathf.Clamp(currentPosition.x, leftWallPositionX, rightWallPositionX);

        this.transform.position = currentPosition;

        if (Input.GetKeyDown("space"))
        {
            Instantiate(Coin, this.transform.position, this.transform.rotation);
        }
    }
}
