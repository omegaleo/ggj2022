using System;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class MessageOption
    {
        public string text;
        public UnityAction action;

        public MessageOption(string text)
        {
            this.text = text;
        }
    }

    public class AudioManager : MonoBehaviour
    {
        public AudioSource source;

        private void Start()
        {
            source = GetComponent<AudioSource>();
        }
    }

    public enum SFXTypes
    {
        TitleScreen,
        Lever,
        Money
    }

    [System.Serializable]
    public class SFXAssociation
    {
        public SFXTypes type;
        public AudioClip clip;
    }
}