using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [Header("First level")] 
    public int moneyBags;

    public bool firstLevelGood;

    public bool firstLevelBad
    {
        get
        {
            return moneyBags > 0 && !firstLevelGood && !firstLevelNeutral;
        }
    }

    public bool firstLevelNeutral
    {
        get
        {
            return moneyBags == 0 && !firstLevelGood && !firstLevelBad;
        }
    }
    
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
}
