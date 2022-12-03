using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace MyGame
{
    public class MalusConfig : MonoBehaviour
    {
        public Malus malus;
        public Malus myMalus;

        public void ConfigureMalus(Malus malus)
        {
            //affichage du malus

            transform.GetChild(0).GetComponent<Text>().text = malus.alertLevel.ToString();
            transform.GetChild(1).GetComponent<Text>().text = malus.malusDescription;
            transform.GetChild(2).GetComponent<Image>().sprite = malus.malusSprite;
            transform.GetChild(2).GetChild(0).GetComponent<Text>().text = malus.malusEffectText;
            myMalus = malus;
            ApplyMalus(myMalus);

        }

        public void ApplyMalus(Malus malus)
        {
            CardManager.InitValues();

            CardManager.FoodChange(malus.foodMalus);
            CardManager.ArmyChange(malus.armyMalus);
            CardManager.GoldChange(malus.goldMalus);
            CardManager.HappinessChange(malus.happinessMalus);
            CardManager.PeopleChange(malus.peopleMalus);

            // ------------ DEBUG ------------//
            /*
            Debug.Log("foodMalus : " + malus.foodMalus);
            Debug.Log("armyMalus : " + malus.armyMalus);
            Debug.Log("goldMalus : " + malus.goldMalus);
            Debug.Log("happyMalus : " + malus.happinessMalus);
            Debug.Log("peopleMalus : " + malus.peopleMalus);
            */
        }

    }
}