using UnityEngine;

namespace DefaultNamespace
{
    public static class MethodExtensions
    {
        public static Color ColorFromHex(this string hex)
        {
            Color color;
            ColorUtility.TryParseHtmlString(hex, out color);
            return color;
        }
    }
}