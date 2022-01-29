using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Validator : MonoBehaviour
{
    private bool checkedLevel2Flag;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GameController.instance.firstLevelBad = GameController.instance.moneyBags > 0;

            if (!checkedLevel2Flag) checkedLevel2Flag = true; // Check so that it doesn't instantly change to bad as soon as the player goes into the 2nd floor
            else if(!GameController.instance.secondLevelGood && !GameController.instance.secondLevelNeutral) GameController.instance.secondLevelBad = true; //Set to bad if player fled without helping
        }
    }
}
