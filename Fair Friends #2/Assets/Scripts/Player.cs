using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float x, y, z;
    private Vector3 pos;
    private const float speed = .02f;

    void Start()
    {
        x = 0;
        y = 0;
        z = -1;
        pos = new Vector3(x, y, z);
        transform.position = pos;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            y += speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            x -= speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            x += speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            y -= speed;
        }

        transform.position = new Vector3(x, y, z);
    }
}
