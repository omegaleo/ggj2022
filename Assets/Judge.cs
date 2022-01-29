using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Judge : MonoBehaviour
{
    [SerializeField] private Sprite goodSprite;
    [SerializeField] private Sprite badSprite;
    [SerializeField] private Sprite neutralSprite;

    private SpriteRenderer sprite;
    
    public static Judge instance;

    private void Awake()
    {
        instance = this;
    }
    
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        int goodPoints = GameController.instance.GetGoodPoints();
        int badPoints = GameController.instance.GetBadPoints();

        if (goodPoints > badPoints)
        {
            sprite.sprite = goodSprite;
        }
        else if (goodPoints < badPoints)
        {
            sprite.sprite = badSprite;
        }
        else
        {
            sprite.sprite = neutralSprite;
        }
    }

    void AddMessage(string message)
    {
        MessageQueue.instance.messages.Add(message);
    }
    
    public void JudgePlayer()
    {
        int goodPoints = GameController.instance.GetGoodPoints();
        int badPoints = GameController.instance.GetBadPoints();

        if (goodPoints > badPoints)
        {
            AddMessage("Greetings, I'm here to judge the choices you've made before arriving here.");

            if (GameController.instance.firstLevelGood)
            {
                AddMessage("It seems that you helped the man recover his lost bags of money, that was a good action.");
            }
            else if (GameController.instance.firstLevelNeutral)
            {
                AddMessage("It seems that you didn't help recover the lost bags of money, it was neither a good nor a bad action.");
            }

            if (GameController.instance.secondLevelGood)
            {
                AddMessage("Excellent, you found the hidden lever that could save both lifes, good job.");
            }
            else if (GameController.instance.secondLevelNeutral)
            {
                AddMessage("It seems you only managed to save one life in the second room, there was a way to save both but you shouldn't feel bad for not knowing about it.");
            }
            
            AddMessage("Overall you are a good person and you should continue being like that.");
        }
        else if (goodPoints < badPoints)
        {
            AddMessage("About time you got here, hope you're ready to be judged for your actions.");

            if (GameController.instance.firstLevelBad)
            {
                if (GameController.instance.moneyBags > 0)
                {
                    AddMessage("Hmmm, so you decided to keep the money bags instead giving to the person who lost them? That was quite evil.");
                }
                else
                {
                    AddMessage("So, you decided to give the money bags with the shady person instead of giving back to it's owner? Not exactly evil, but still bad.");
                }
            }
            else if (GameController.instance.firstLevelNeutral)
            {
                AddMessage("So you didn't help recover the lost bags of money, it was neither a good nor a bad action.");
            }

            if (GameController.instance.secondLevelBad)
            {
                AddMessage("Back in the previous room, you decided to abandon both of them to die? That was really evil.");
            }
            else if (GameController.instance.secondLevelNeutral)
            {
                AddMessage("In the previous room you managed to save one of them? Hmmmm, not as evil as if you had abandoned both, but also not that good.");
            }
            
            AddMessage("Overall you are an evil person, which in my opinion is really good, good job.");
        }
        else
        {
            AddMessage("Hello, I'll be your judge for today.");

            if (GameController.instance.firstLevelGood)
            {
                AddMessage("You helped the man recover his lost bags of money, that was a good action.");
            }
            else if (GameController.instance.firstLevelNeutral)
            {
                AddMessage("You didn't help recover the lost bags of money, it was neither a good nor a bad action.");
            }
            else if (GameController.instance.firstLevelBad)
            {
                if (GameController.instance.moneyBags > 0)
                {
                    AddMessage("You decided to keep the money bags instead giving to the person who lost them? That was a bad action.");
                }
                else
                {
                    AddMessage("So, you decided to give the money bags with the shady person instead of giving back to it's owner? Not exactly bad but also not good.");
                }
            }
            
            if (GameController.instance.secondLevelGood)
            {
                AddMessage("In the previous room you found the hidden lever that could save both lifes, that was pretty smart of you and a good action.");
            }
            else if (GameController.instance.secondLevelBad)
            {
                AddMessage("Back in the previous room, you decided to abandon both of them to die? That was really bad.");
            }
            else if (GameController.instance.secondLevelNeutral)
            {
                AddMessage("You only managed to save one life in the second room, there was a way to save both. It was still good but not as good as if you had saved both.");
            }
            
            AddMessage("Overall you're neither good nor bad in general, you stand in the line between both.");
        }

        StartCoroutine(AwaitForEndScreen());
    }

    IEnumerator AwaitForEndScreen()
    {
        while (MessageQueue.instance.messages.Count > 0)
        {
            yield return new WaitForSeconds(1f);
        }
        
        GameEndScreen.instance.Open();
    }
}
