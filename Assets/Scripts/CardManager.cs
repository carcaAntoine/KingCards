using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace MyGame
{
    public class CardManager : MonoBehaviour
    {
        /*------------------ NOURRITURE ------------------*/
        static private Text foodIncomeText; //income nourriture (GameObject)
        static private Text foodValueText;  //valeur nourriture (GameObject)
        static public int foodValue;  //valeur de la nourriture à ajouter
        static private int foodIncome; //valeur de l'income à ajouter

        /*------------------ ARMEE ------------------*/
        static private Text armyValueText; //valeur armée (GameObject)
        static public int armyValue; //valeur armée à ajouter

        /*------------------ ARGENT ------------------*/
        static private Text goldIncomeText; //income argent (GameObject)
        static private Text goldValueText;  //valeur argent (GameObject)
        static public int goldValue;  //valeur de l'argent à ajouter
        static private int goldIncome; //valeur de l'income à ajouter

        /*------------------ BONHEUR ------------------*/
        static private Text bonheurValueText;
        static public int bonheurValue;

        /*------------------ POPULATION ------------------*/
        static private Text peopleValueText;
        static public int peopleValue;
        
        /*--------------------------------------------*/

        public static void CheckValues()
        {
            foodValueText = GameObject.Find("FoodValue").GetComponent<Text>();
            foodValue = Convert.ToInt32(foodValueText.text);

            goldValueText = GameObject.Find("GoldValue").GetComponent<Text>();
            goldValue = Convert.ToInt32(goldValueText.text);

            armyValueText = GameObject.Find("ArmyValue").GetComponent<Text>();
            armyValue = Convert.ToInt32(armyValueText.text);

            bonheurValueText = GameObject.Find("BonheurValue").GetComponent<Text>();
            bonheurValue = Convert.ToInt32(bonheurValueText.text);

            /*evolutionValueText = GameObject.Find("EvolutionValue").GetComponent<Text>();
            evolutionValue = Convert.ToInt32(evolutionValueText.text);*/
        }
        static public void LoiAgricoleCard()
        {
            foodIncomeText = GameObject.Find("FoodIncome").GetComponent<Text>();
            foodIncome = (Convert.ToInt32(foodIncomeText.text)) + 5;
            foodIncomeText.text = foodIncome.ToString();

        }

        static public void LoiFiscaleCard()
        {
            goldIncomeText = GameObject.Find("GoldIncome").GetComponent<Text>();
            goldIncome = (Convert.ToInt32(goldIncomeText.text)) + 10;
            goldIncomeText.text = goldIncome.ToString();
        }

        static public void LoiMartialeCard()
        {
            armyValueText = GameObject.Find("ArmyValue").GetComponent<Text>();
            armyValue = (Convert.ToInt32(armyValueText.text)) + 50;
            armyValueText.text = armyValue.ToString();
        }

        static public void Convoi()
        {
            foodValueText = GameObject.Find("FoodValue").GetComponent<Text>();
            foodValue = (Convert.ToInt32(foodValueText.text) + 50);
            foodValueText.text = foodValue.ToString();
        }

        static public void Education()
        {
            /*evolutionValueText = GameObject.Find("EvolutionValue").GetComponent<Text>();
            evolutionValue = (Convert.ToInt32(evolutionValueText.text) + 2);
            evolutionValueText.text = evolutionValue.ToString();*/

            goldValueText = GameObject.Find("GoldValue").GetComponent<Text>();
            goldValue = (Convert.ToInt32(goldValueText.text) - 50);
            goldValueText.text = goldValue.ToString();
        }

        static public void Impots()
        {
            goldValueText = GameObject.Find("GoldValue").GetComponent<Text>();
            goldValue = (Convert.ToInt32(goldValueText.text) + 50);
            goldValueText.text = goldValue.ToString();
        }

        static public void JoiesDeLaRue()
        {
            bonheurValueText = GameObject.Find("BonheurValue").GetComponent<Text>();
            bonheurValue = (Convert.ToInt32(bonheurValueText.text) - 5);
            bonheurValueText.text = bonheurValue.ToString();

            goldValueText = GameObject.Find("GoldValue").GetComponent<Text>();
            goldValue = (Convert.ToInt32(goldValueText.text) + 15);
            goldValueText.text = goldValue.ToString();
        }

        static public void NouvelleTaxe()
        {
            bonheurValueText = GameObject.Find("BonheurValue").GetComponent<Text>();
            bonheurValue = (Convert.ToInt32(bonheurValueText.text) - 10);
            bonheurValueText.text = bonheurValue.ToString();

            goldIncomeText = GameObject.Find("GoldIncome").GetComponent<Text>();
            goldIncome = (Convert.ToInt32(goldIncomeText.text)) + 5;
            goldIncomeText.text = goldIncome.ToString();
        }
    }
}