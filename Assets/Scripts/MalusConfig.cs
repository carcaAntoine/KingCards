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
        public int malusValue;

        public void UseMalusValue(Malus malus)
        {
            if(malus.foodMalus != 0)
            {
                malusValue = malus.foodMalus * AgeConfig.actualAgeNumber;
            }
            else if(malus.armyMalus != 0)
            {
                malusValue = malus.armyMalus * AgeConfig.actualAgeNumber;
            }
            else if(malus.goldMalus != 0)
            {
                malusValue = malus.goldMalus * AgeConfig.actualAgeNumber;
            }
            else if(malus.happinessMalus != 0)
            {
                malusValue = malus.happinessMalus * AgeConfig.actualAgeNumber;
            }
            else
            {
                malusValue = malus.peopleMalus * AgeConfig.actualAgeNumber;
            }
        }

        public void ConfigureMalus(Malus malus)
        {
            //affichage du malus
            UseMalusValue(malus);
            transform.GetChild(0).GetComponent<Text>().text = malus.alertLevel.ToString();
            transform.GetChild(1).GetComponent<Text>().text = malus.malusDescription;
            transform.GetChild(2).GetComponent<Image>().sprite = malus.malusSprite;
            transform.GetChild(2).GetChild(0).GetComponent<Text>().text = malus.malusEffectText + malusValue;
            myMalus = malus;
            ApplyMalus(myMalus);

        }

        public void ApplyMalus(Malus malus)
        {
            CardManager.InitValues();

            CardManager.FoodChange(malus.foodMalus * AgeConfig.actualAgeNumber);
            CardManager.ArmyChange(malus.armyMalus * AgeConfig.actualAgeNumber);
            CardManager.GoldChange(malus.goldMalus * AgeConfig.actualAgeNumber);
            CardManager.HappinessChange(malus.happinessMalus * AgeConfig.actualAgeNumber);
            CardManager.PeopleChange(malus.peopleMalus * AgeConfig.actualAgeNumber);

            // ------------ DEBUG ------------//
            
            Debug.Log("foodMalus : " + malus.foodMalus * AgeConfig.actualAgeNumber);
            Debug.Log("armyMalus : " + malus.armyMalus * AgeConfig.actualAgeNumber);
            Debug.Log("goldMalus : " + malus.goldMalus * AgeConfig.actualAgeNumber);
            Debug.Log("happyMalus : " + malus.happinessMalus * AgeConfig.actualAgeNumber);
            Debug.Log("peopleMalus : " + malus.peopleMalus * AgeConfig.actualAgeNumber);
            
        }

    }
}