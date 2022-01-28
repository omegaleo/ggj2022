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
}