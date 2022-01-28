using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageQueue : MonoBehaviour
{
    public List<string> messages = new List<string>();

    [SerializeField]
    private TMPro.TMP_Text text;

    private bool canRemove = true;
    
    public static MessageQueue instance;

    private Vector3 showPosition;
    private Vector3 hidePosition;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        showPosition = transform.localPosition;
        hidePosition = new Vector3(showPosition.x, showPosition.y - 600, showPosition.z);
    }

    private void Update()
    {
        if (messages.Count > 0)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, showPosition, 0.125f);
            if (text.text != messages[0])
            {
                text.text = messages[0];
            }

            if (Input.GetKeyDown(KeyCode.Z) && canRemove)
            {
                messages.Remove(messages[0]);
                canRemove = false;
                StartCoroutine(WaitForNextMessage());
            }
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, hidePosition, 0.125f);
        }
    }

    IEnumerator WaitForNextMessage()
    {
        yield return new WaitForSeconds(0.1f);
        canRemove = true;
    }
}
