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
            PlayerPrefs.SetInt("10Tours", 1);
        }

        public void FonctionErase()
        {
            PlayerPrefs.DeleteKey("10Tours");
            PlayerPrefs.DeleteKey("NbrParties");
            PlayerPrefs.DeleteKey("10Parties");
            PlayerPrefs.DeleteKey("50Tours");
            PlayerPrefs.DeleteKey("Empire");
            PlayerPrefs.DeleteKey("Tresor");
            PlayerPrefs.DeleteKey("Festin");
            PlayerPrefs.DeleteKey("Population");
            PlayerPrefs.DeleteKey("NbrCatastrophes");
        }
    }
}