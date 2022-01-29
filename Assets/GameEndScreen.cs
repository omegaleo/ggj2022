using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndScreen : MonoBehaviour
{
    public static GameEndScreen instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private Image image;
    [SerializeField] private TMP_Text text;

    private bool canClose = false;
    
    public bool IsOpen()
    {
        return image.enabled;
    }

    private void Update()
    {
        if (IsOpen() && Input.anyKey && canClose)
        {
            SceneManager.LoadScene(0);
            image.enabled = false;
            text.enabled = false;
        }
    }

    public void Open()
    {
        image.enabled = true;
        text.enabled = true;
        StartCoroutine(WaitToClose());
    }

    IEnumerator WaitToClose()
    {
        yield return new WaitForSeconds(2f);
        canClose = true;
    }
}
