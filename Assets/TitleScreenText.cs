using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            SFX.instance.Play(SFXTypes.TitleScreen);
            SceneManager.LoadScene(1);
        }
    }
}
