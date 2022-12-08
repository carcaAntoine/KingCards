using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace MyGame
{
    public class AgeConfig : MonoBehaviour
    {
        public Age age;
        public Age myAge;

        public void ConfigureAge(Age age)
        {
            transform.GetChild(1).GetComponent<Text>().text = age.annonce;
            transform.GetChild(2).GetComponent<Text>().text = age.ageName;
            transform.GetChild(3).GetComponent<Text>().text = age.effectsDescription;
        }
    }
}