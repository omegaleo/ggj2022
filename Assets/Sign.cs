using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    [SerializeField] private string text;

    private bool isPlayerColliding = false;

    private bool messageSent = false;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerColliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerColliding = false;
            messageSent = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerColliding && !messageSent)
        {
            MessageQueue.instance.messages.Add(text);
            messageSent = true;
        }
    }
}
