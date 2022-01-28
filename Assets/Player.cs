using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    private Rigidbody2D body;
    
    public float runSpeed = 6.0f;
    private void Awake()
    {
        instance = this;
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if ((horizontal != 0f || vertical != 0f) && CanMove())
        {
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
        else
        {
            body.velocity = Vector2.zero;
        }
    }

    bool CanMove()
    {
        return MessageQueue.instance.messages.Count == 0;
    }
}
