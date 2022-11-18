using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public static class RemoveClone
    {
        public static string RemoveCloneEnd(this string str, int len)
        {
            if (str.Length < len)
            {
                return string.Empty;
            }
            return str.Remove(str.Length - len);
        }
    }
}