using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public bool isMoneyNPC;
    public bool isFakeMoneyNPC;

    private bool isPlayerColliding = false;

    private bool messageSent = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerColliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerColliding = false;
            messageSent = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((isMoneyNPC || isFakeMoneyNPC) && (GameController.instance.firstLevelGood || GameController.instance.firstLevelNeutral)) Destroy(this.gameObject);
        
        if (isPlayerColliding && !messageSent)
        {
            if (isMoneyNPC)
            {
                
                
                if (GameController.instance.moneyBags == 0)
                {
                    MessageQueue.instance.messages.Add("Oh dear, it seems I've misplaced my money bags, hey you there, can you be a gentleman and find them for me?");
                }
                else if (GameController.instance.moneyBags == 3)
                {
                    MessageQueue.instance.messages.Add("Did you find them?");

                    MessageOption yes = new MessageOption("Yes");
                    yes.action += () => 
                    { 
                        GameController.instance.moneyBags = 0;
                        GameController.instance.firstLevelGood = true;
                        GameController.instance.firstLevelBad = false;
                        MessageQueue.instance.messages.Add("Thank you! I owe you one for this!");
                    };

                    MessageOption no = new MessageOption("No");
                    no.action += () =>
                    {
                        MessageQueue.instance.messages.Add("Oh, that's a shame, well, continue the good work!");
                    };
                    
                    MessageQueue.instance.options = new List<MessageOption>()
                    {
                        yes,
                        no
                    };
                }
            }
            if (isFakeMoneyNPC)
            {
                if (GameController.instance.moneyBags == 0)
                {
                    MessageQueue.instance.messages.Add("Hey there, it appears that there are money bags around here, mind collecting them for me? I'll split the cash 50/50");
                }
                else if (GameController.instance.moneyBags == 3)
                {
                    MessageQueue.instance.messages.Add("Did you find them?");

                    MessageOption yes = new MessageOption("Yes");
                    yes.action += () => 
                    { 
                        GameController.instance.moneyBags = 0;
                        GameController.instance.firstLevelBad = false;
                        GameController.instance.firstLevelNeutral = true;
                        MessageQueue.instance.messages.Add("Awesome, now beat it chump, thanks for the free money!");
                    };

                    MessageOption no = new MessageOption("No");
                    no.action += () =>
                    {
                        MessageQueue.instance.messages.Add("Bummer, well, continue looking!");
                    };

                    MessageQueue.instance.options = new List<MessageOption>()
                    {
                        yes,
                        no
                    };
                }
            }
            
            messageSent = true;
        }
    }
}
