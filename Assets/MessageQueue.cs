using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class MessageQueue : MonoBehaviour
{
    public List<string> messages = new List<string>();
    public List<MessageOption> options = new List<MessageOption>();
    
    [SerializeField]private TMPro.TMP_Text text;

    private bool canRemove = true;
    
    public static MessageQueue instance;

    private Vector3 showPosition;
    private Vector3 hidePosition;

    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private Button choice1;
    [SerializeField] private Button choice2;
    private Image panel;
    private bool optionsSet = false;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        showPosition = transform.localPosition;
        hidePosition = new Vector3(showPosition.x, showPosition.y - 600, showPosition.z);
        panel = GetComponent<Image>();
    }

    private void Update()
    {
        if (messages.Count > 0 || options.Count > 0)
        {
            Color color = GameController.instance.GetColor();
            panel.color = color;
            transform.localPosition = Vector3.Lerp(transform.localPosition, showPosition, 0.125f);

            if (messages.Count > 0)
            {
                if (text.text != messages[0])
                {
                    text.text = messages[0];
                }
            }

            if (options.Count > 0 && !optionsSet)
            {
                optionsPanel.SetActive(true);
                optionsPanel.GetComponent<Image>().color = color;
                choice1.onClick.AddListener(() =>
                {
                    options[0].action.Invoke();
                    ClearOptions();
                    NextMessage();
                });

                choice1.GetComponent<Image>().color = color;
                choice1.transform.GetChild(0).GetComponent<TMP_Text>().text = options[0].text;
                
                choice2.onClick.AddListener(() =>
                {
                    options[1].action.Invoke();
                    ClearOptions();
                    NextMessage();
                });

                choice2.GetComponent<Image>().color = color;
                choice2.transform.GetChild(0).GetComponent<TMP_Text>().text = options[1].text;
                
                optionsSet = true;
            }
            
            if (Input.GetKeyDown(KeyCode.Z) && canRemove && messages.Count > 0)
            {
                NextMessage();
            }
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, hidePosition, 0.125f);
        }
    }

    public void NextMessage()
    {
        messages.Remove(messages[0]);
        canRemove = false;
        StartCoroutine(WaitForNextMessage());
    }
    
    void ClearOptions()
    {
        options.Clear();
        optionsSet = false;
        optionsPanel.SetActive(false);
    }
    
    IEnumerator WaitForNextMessage()
    {
        yield return new WaitForSeconds(0.1f);
        canRemove = true;
    }
}
