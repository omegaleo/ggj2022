using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class Music : AudioManager
{
    public static Music instance;

    private void Awake()
    {
        instance = this;
    }
    
    // Update is called once per frame
    void Update()
    {
        int goodPoints = GameController.instance.GetGoodPoints();
        int badPoints = GameController.instance.GetBadPoints();

        if (goodPoints > badPoints)
        {
            source.pitch = 1.31f;
        }
        else if (badPoints > goodPoints)
        {
            source.pitch = 0.61f;
        }
        else
        {
            source.pitch = 1f;
        }
    }
}
