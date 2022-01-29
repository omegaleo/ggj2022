using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using DefaultNamespace;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [Header("First level")] 
    public int moneyBags;

    public bool firstLevelGood;

    public bool firstLevelBad;
    
    public bool firstLevelNeutral;
    
    [Header("Second level")]
    public bool secondLevelGood;

    public bool secondLevelBad;
    
    public bool secondLevelNeutral;
    
    [Header("Third level")]
    public bool thirdLevelGood;

    public bool thirdLevelBad;

    private void Awake()
    {
        instance = this;
    }

    public int GetGoodPoints()
    {
        int goodPoints = 0;
        if (firstLevelGood) goodPoints++;
        if (secondLevelGood) goodPoints++;
        if (thirdLevelGood) goodPoints++;

        return goodPoints;
    }

    public int GetBadPoints()
    {
        int badPoints = 0;
        if (firstLevelBad) badPoints++;
        if (secondLevelBad) badPoints++;
        if (thirdLevelBad) badPoints++;

        return badPoints;
    }
    
    public Color GetColor()
    {
        int goodPoints = GetGoodPoints();
        int badPoints = GetBadPoints();

        if (goodPoints > badPoints)
        {
            int points = goodPoints - badPoints;

            switch (points)
            {
                case 1:
                    return "#0cfffb".ColorFromHex();
                case 2:
                    return "#3cfffc".ColorFromHex();
                case 3:
                    return "#64fdfb".ColorFromHex();
            }
        }
        
        if (badPoints > goodPoints)
        {
            int points = badPoints - goodPoints;
            switch (points)
            {
                case 1:
                    return "#E63636".ColorFromHex();
                case 2:
                    return "#C52424".ColorFromHex();
                case 3:
                    return "#9E1313".ColorFromHex();
            }
        }
        
        return Color.white;
    }
}
