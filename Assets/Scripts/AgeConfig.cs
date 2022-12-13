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
        public static int actualAgeNumber = 1; //nombre de l'ère actuelle ( /!\ PAS INDEX /!\ )
        public static int armyCostValue = 1;
        public static int peopleAdd = 5; //nombre d'habitants ajoutés naturellement
        public static int minCardIndex = 0; //index minimum des cards sélectionnables
        public static int maxCardIndex = 17; //index maximum des cards sélectionnables


        public void ConfigureAge(Age age)
        {
            transform.GetChild(1).GetComponent<Text>().text = age.annonce;
            transform.GetChild(2).GetComponent<Text>().text = age.ageName;
            transform.GetChild(3).GetComponent<Text>().text = age.effectsDescription;
            myAge = age;
            ChangeAge(age);
        }

        public void ChangeAge(Age age)
        {
            actualAgeNumber += 1;
            armyCostValue = age.ArmyCostValue;
            peopleAdd = age.peopleAddValue;
            minCardIndex = age.indexMinCard;
            maxCardIndex = age.indexMaxCard;

            Debug.Log(age.ageName);
            Debug.Log("army cost : " + armyCostValue);
            Debug.Log("people add : " + peopleAdd);
        }

        public void ReInitValues()
        {
            actualAgeNumber = 1;
            armyCostValue = 1;
            peopleAdd = 5;
            minCardIndex = 0;
            maxCardIndex = 17;
        }
    }
}