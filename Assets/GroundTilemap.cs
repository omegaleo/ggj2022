using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundTilemap : MonoBehaviour
{
    public static GroundTilemap instance;

    private Tilemap tilemap;

    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }
    
    private void Awake()
    {
        instance = this;
    }

    public void SetColor(Color color)
    {
        tilemap.color = color;
    }
}
