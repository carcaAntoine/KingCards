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

            if (foodValue == 0 || goldValue == 0 || bonheurValue == 0 || peopleValue == 0)
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

        static public void LoiAgricoleCard()
        {

            foodIncomeText = GameObject.Find("FoodIncome").GetComponent<Text>();
            foodIncome = (Convert.ToInt32(foodIncomeText.text)) + 5;
            foodIncomeText.text = foodIncome.ToString();


        }

        static public void LoiFiscaleCard()
        {
            goldIncomeText = GameObject.Find("GoldIncome").GetComponent<Text>();
            goldIncome = (Convert.ToInt32(goldIncomeText.text)) + 5;
            goldIncomeText.text = goldIncome.ToString();
        }

        static public void LoiMartialeCard()
        {
            armyValueText = GameObject.Find("ArmyValue").GetComponent<Text>();
            armyValue = (Convert.ToInt32(armyValueText.text)) + 10;
            armyValueText.text = armyValue.ToString();
            goldIncomeText = GameObject.Find("GoldIncome").GetComponent<Text>();
            goldIncome = (Convert.ToInt32(goldIncomeText.text)) - 10;
            goldIncomeText.text = goldIncome.ToString();
        }

        static public void Convoi()
        {
            foodValueText = GameObject.Find("FoodValue").GetComponent<Text>();
            foodValue = (Convert.ToInt32(foodValueText.text) + 50);
            foodValueText.text = foodValue.ToString();
        }

        static public void Education()
        {
            bonheurValueText = GameObject.Find("BonheurValue").GetComponent<Text>();
            bonheurValue = (Convert.ToInt32(bonheurValueText.text) + 5);
            bonheurValueText.text = bonheurValue.ToString();

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

        public static void LibrePassage()
        {
            peopleValueText = GameObject.Find("PeopleValue").GetComponent<Text>();
            peopleValue = Convert.ToInt32(peopleValueText.text) + 5;
            peopleValueText.text = peopleValue.ToString();
        }

    }
}