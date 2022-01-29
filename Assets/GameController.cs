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
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public Color GetColor()
    {
        int goodPoints = 0;
        int badPoints = 0;

        if (firstLevelGood) goodPoints++;
        if (firstLevelBad || firstLevelNeutral) badPoints++; //Since you gave the bags to the fake
        if (secondLevelBad) badPoints++;
        if (secondLevelGood) goodPoints++;
        if (thirdLevelBad) badPoints++;
        if (thirdLevelGood) goodPoints++;

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
