using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float x, y;
    private const float z = -1;
    private Vector3 pos; // Prob don't need
    private const float speed = .2f;
    public SpriteRenderer spriteRenderer;
    public Sprite forward;
    public Sprite backwards;

    void Start()
    {
        x = 0;
        y = 0;
        pos = new Vector3(x, y, z);
        transform.position = pos;
        spriteRenderer.sprite = forward;
    }


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if(spriteRenderer.sprite != forward)
            {
                spriteRenderer.sprite = forward;
            }
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
            if (spriteRenderer.sprite != backwards)
            {
                spriteRenderer.sprite = backwards;
            }
            y -= speed;
        }

        pos = new Vector3(x, y, z);
        transform.position = pos;
    }
}
