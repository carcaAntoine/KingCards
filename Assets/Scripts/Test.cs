using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace MyGame
{
    public class Test : MonoBehaviour
    {
        public void FonctionTest()
        {
            PlayerPrefs.GetInt("10Tours");
        }
    }
}