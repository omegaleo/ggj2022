using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeCollider : MonoBehaviour
{
    private bool judging = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && !judging)
        {
            judging = true;
            Judge.instance.JudgePlayer();
        }
    }
}
