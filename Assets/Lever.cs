using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private bool isLeft;
    [SerializeField] private bool isRight;
    [SerializeField] private bool isBoth;

    private bool isCollidingWithPlayer;
    private bool messageSent;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isCollidingWithPlayer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isCollidingWithPlayer = false;
        }
    }

    private void Update()
    {
        if (Level2Doors.instance.leverFlipped) Destroy(this.gameObject);
        
        if (isCollidingWithPlayer && Input.GetKeyDown(KeyCode.Z) && !messageSent)
        {
            messageSent = true;
            
            MessageQueue.instance.messages.Add("It's a lever." + Environment.NewLine + "Do you want to flip it?");

            MessageOption yes = new MessageOption("Yes");
            yes.action += () => 
            { 
                Open();
            };

            MessageOption no = new MessageOption("No");
            no.action += () =>
            {
                messageSent = false;
            };

            MessageQueue.instance.options = new List<MessageOption>()
            {
                yes,
                no
            };
        }
    }

    public void Open()
    {
        if (isBoth)
        {
            Level2Doors.instance.OpenBoth();
        }

        if (isLeft)
        {
            Level2Doors.instance.OpenLeftDoor(true);
        }

        if (isRight)
        {
            Level2Doors.instance.OpenRightDoor(true);
        }

        Level2Doors.instance.leverFlipped = true;
    }
}
