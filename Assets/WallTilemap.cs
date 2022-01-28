using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallTilemap : MonoBehaviour
{
    public static WallTilemap instance;

    private Tilemap tilemap;

    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        tilemap.color = GameController.instance.GetColor();
    }
}
