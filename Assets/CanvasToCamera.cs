using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasToCamera : MonoBehaviour
{
    private Canvas canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        canvas = this.GetComponent<Canvas>();
        SetCamera();
        SceneManager.activeSceneChanged += ActiveSceneChanged;
    }

    private void ActiveSceneChanged(Scene arg0, Scene arg1)
    {
        SetCamera();
    }

    private void SetCamera()
    {
        var camera = GameObject.FindGameObjectWithTag("MainCamera");
        canvas.worldCamera = camera.GetComponent<Camera>();
    }
}
