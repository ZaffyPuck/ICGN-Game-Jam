﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float x, y;
    private const float z = -1;
    private Vector3 pos; // Prob don't need
    private const float speed = .15f;
    public SpriteRenderer spriteRenderer;
    public Sprite forward;
    public Sprite backwards;

    void Start()
    {
        if (GlobalControl.Instance.PlayerPosition == null)
        {
            pos = transform.position;
        }
        else
        {
            // Saves location when going into minigame
            pos = GlobalControl.Instance.PlayerPosition;
            x = pos.x;
            y = pos.y;
            transform.position = GlobalControl.Instance.PlayerPosition;
        }
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
