using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    public void CopyText()
    {
        GUIUtility.systemCopyBuffer = text.text;
    }
}
