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
        static public Text foodIncomeText; //income nourriture (GameObject)
        static public Text foodValueText;  //valeur nourriture (GameObject)
        static public int foodValue;  //valeur de la nourriture à ajouter
        static public int foodIncome; //valeur de l'income à ajouter

        /*------------------ ARMEE ------------------*/
        static public Text armyValueText; //valeur armée (GameObject)
        static public int armyValue; //valeur armée à ajouter

        /*------------------ ARGENT ------------------*/
        static public Text goldIncomeText; //income argent (GameObject)
        static public Text goldValueText;  //valeur argent (GameObject)
        static public int goldValue;  //valeur de l'argent à ajouter
        static public int goldIncome; //valeur de l'income à ajouter

        /*------------------ BONHEUR ------------------*/
        static public Text bonheurValueText;
        static public int bonheurValue;

        /*------------------ POPULATION ------------------*/
        static public Text peopleValueText;
        static public int peopleValue;

        /*------------------------------------------------*/
        public static bool gameOver = false;

        /*------------------------------------------------*/

        public static void InitValues()
        {
            foodValueText = GameObject.Find("FoodValue").GetComponent<Text>();
            foodValue = Convert.ToInt32(foodValueText.text);
            foodIncomeText = GameObject.Find("FoodIncome").GetComponent<Text>();
            foodIncome = Convert.ToInt32(foodIncomeText.text);

            goldValueText = GameObject.Find("GoldValue").GetComponent<Text>();
            goldValue = Convert.ToInt32(goldValueText.text);
            goldIncomeText = GameObject.Find("GoldIncome").GetComponent<Text>();
            goldIncome = Convert.ToInt32(goldIncomeText.text);

            armyValueText = GameObject.Find("ArmyValue").GetComponent<Text>();
            armyValue = Convert.ToInt32(armyValueText.text);

            bonheurValueText = GameObject.Find("BonheurValue").GetComponent<Text>();
            bonheurValue = Convert.ToInt32(bonheurValueText.text);

            peopleValueText = GameObject.Find("PeopleValue").GetComponent<Text>();
            peopleValue = Convert.ToInt32(peopleValueText.text);
        }

        public static void CheckValues()
        {
            InitValues();

            if (foodValue <= 0 || armyValue <= 0 || goldValue <= 0 || bonheurValue <= 0 || peopleValue <= 0)
            {
                gameOver = true;
            }
        }

        public static void IncomeManager()
        {
            InitValues();

            foodValue = foodValue + foodIncome;
            foodValueText.text = foodValue.ToString();

            goldValue = goldValue + goldIncome;
            goldValueText.text = goldValue.ToString();
        }

        //########################################################################################
        // FONCTIONS DE MODIFICATION DES STATS

        public static void FoodPlus(int val)
        {
            foodValueText = GameObject.Find("FoodValue").GetComponent<Text>();
            foodValue = (Convert.ToInt32(foodValueText.text)) + val;
            foodValueText.text = foodValue.ToString();
        }

        public static void FoodMinus(int val)
        {
            foodValueText = GameObject.Find("FoodValue").GetComponent<Text>();
            foodValue = (Convert.ToInt32(foodValueText.text)) - val;
            foodValueText.text = foodValue.ToString();
        }

        public static void FoodIncomePlus(int val)
        {
            foodIncomeText = GameObject.Find("FoodIncome").GetComponent<Text>();
            foodIncome = (Convert.ToInt32(foodIncomeText.text)) + val;
            foodIncomeText.text = foodIncome.ToString();
        }

        public static void FoodIncomeMinus(int val)
        {
            foodIncomeText = GameObject.Find("FoodIncome").GetComponent<Text>();
            foodIncome = (Convert.ToInt32(foodIncomeText.text)) + val;
            foodIncomeText.text = foodIncome.ToString();
        }

        public static void ArmyPlus(int val)
        {
            armyValueText = GameObject.Find("ArmyValue").GetComponent<Text>();
            armyValue = (Convert.ToInt32(armyValueText.text)) + val;
            armyValueText.text = armyValue.ToString();

            goldIncomeText = GameObject.Find("GoldIncome").GetComponent<Text>();
            goldIncome = (Convert.ToInt32(goldIncomeText.text)) - val;
            goldIncomeText.text = goldIncome.ToString();
        }

        public static void ArmyMinus(int val)
        {
            armyValueText = GameObject.Find("ArmyValue").GetComponent<Text>();
            armyValue = (Convert.ToInt32(armyValueText.text)) - val;
            armyValueText.text = armyValue.ToString();

            goldIncomeText = GameObject.Find("GoldIncome").GetComponent<Text>();
            goldIncome = (Convert.ToInt32(goldIncomeText.text)) + val;
            goldIncomeText.text = goldIncome.ToString();
        }

        public static void GoldPlus(int val)
        {
            goldValueText = GameObject.Find("GoldValue").GetComponent<Text>();
            goldValue = (Convert.ToInt32(goldValueText.text) + val);
            goldValueText.text = goldValue.ToString();
        }

        public static void GoldMinus(int val)
        {
            goldValueText = GameObject.Find("GoldValue").GetComponent<Text>();
            goldValue = (Convert.ToInt32(goldValueText.text) - val);
            goldValueText.text = goldValue.ToString();
        }

        public static void GoldIncomePlus(int val)
        {
            goldIncomeText = GameObject.Find("GoldIncome").GetComponent<Text>();
            goldIncome = (Convert.ToInt32(goldIncomeText.text)) + val;
            goldIncomeText.text = goldIncome.ToString();
        }

        public static void GoldIncomeMinus(int val)
        {
            goldIncomeText = GameObject.Find("GoldIncome").GetComponent<Text>();
            goldIncome = (Convert.ToInt32(goldIncomeText.text)) - val;
            goldIncomeText.text = goldIncome.ToString();
        }

        public static void BonheurPlus(int val)
        {
            bonheurValueText = GameObject.Find("BonheurValue").GetComponent<Text>();
            bonheurValue = (Convert.ToInt32(bonheurValueText.text) + val);
            bonheurValueText.text = bonheurValue.ToString();
        }

        public static void BonheurMinus(int val)
        {
            bonheurValueText = GameObject.Find("BonheurValue").GetComponent<Text>();
            bonheurValue = (Convert.ToInt32(bonheurValueText.text) - val);
            bonheurValueText.text = bonheurValue.ToString();
        }

        public static void PeoplePlus(int val)
        {
            peopleValueText = GameObject.Find("PeopleValue").GetComponent<Text>();
            peopleValue = Convert.ToInt32(peopleValueText.text) + val;
            peopleValueText.text = peopleValue.ToString();

            foodIncomeText = GameObject.Find("FoodIncome").GetComponent<Text>();
            foodIncome = Convert.ToInt32(foodIncomeText.text) - val;
            foodIncomeText.text = foodIncome.ToString();
        }

        public static void PeopleMinus(int val)
        {
            peopleValueText = GameObject.Find("PeopleValue").GetComponent<Text>();
            peopleValue = Convert.ToInt32(peopleValueText.text) - val;
            peopleValueText.text = peopleValue.ToString();

            foodIncomeText = GameObject.Find("FoodIncome").GetComponent<Text>();
            foodIncome = Convert.ToInt32(foodIncomeText.text) + val;
            foodIncomeText.text = foodIncome.ToString();
        }

        //########################################################################################

    }
}