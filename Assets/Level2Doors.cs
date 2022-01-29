using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Level2Doors : MonoBehaviour
{
    public static Level2Doors instance;

    [SerializeField] private Vector3 leftDoorPosition;
    [SerializeField] private Vector3 rightDoorPosition;
    [SerializeField] private Tilemap tilemap;

    public bool leverFlipped = false;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    public void OpenLeftDoor(bool neutral)
    {
        tilemap.SetTile(new Vector3Int((int)leftDoorPosition.x, (int)leftDoorPosition.y, (int)leftDoorPosition.z), null);
        
        GameController.instance.secondLevelNeutral = neutral;
        GameController.instance.secondLevelBad = false;
    }
    
    public void OpenRightDoor(bool neutral)
    {
        tilemap.SetTile(new Vector3Int((int)rightDoorPosition.x, (int)rightDoorPosition.y, (int)rightDoorPosition.z), null);
        
        GameController.instance.secondLevelNeutral = neutral;
        GameController.instance.secondLevelBad = false;
    }

    public void OpenBoth()
    {
        OpenLeftDoor(false);
        OpenRightDoor(false);
        GameController.instance.secondLevelGood = true;
    }
}
