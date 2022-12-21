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
        static public Text happyValueText;
        static public int happyValue;

        /*------------------ POPULATION ------------------*/
        static public Text peopleValueText;
        static public int peopleValue;

        /*------------------ POPULATION ------------------*/
        static public Text evolutionValueText;
        static public int evolutionValue;

        /*------------------------------------------------*/
        public static bool gameOver = false;
        public AgeConfig ageConfig;

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

            happyValueText = GameObject.Find("BonheurValue").GetComponent<Text>();
            happyValue = Convert.ToInt32(happyValueText.text);

            peopleValueText = GameObject.Find("PeopleValue").GetComponent<Text>();
            peopleValue = Convert.ToInt32(peopleValueText.text);

            if(GameManager.singleton.evolutionIsActive)
            {
            evolutionValueText = GameObject.Find("EvolutionValue").GetComponent<Text>();
            evolutionValue = Convert.ToInt32(evolutionValueText.text);
            }
        }

        public static void CheckValues()
        {
            InitValues();

            if (foodValue <= 0 || armyValue <= 0 || goldValue <= 0 || happyValue <= 0 || peopleValue <= 0)
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

        public static void FoodChange(int val)
        {
            foodValue = (Convert.ToInt32(foodValueText.text)) + val;
            foodValueText.text = foodValue.ToString();
        }

        public static void FoodIncomeChange(int val)
        {
            foodIncome = (Convert.ToInt32(foodIncomeText.text)) + val;
            foodIncomeText.text = foodIncome.ToString();
        }

        public static void ArmyChange(int val)
        {
            armyValue = (Convert.ToInt32(armyValueText.text)) + val;
            armyValueText.text = armyValue.ToString();

            goldIncome = (Convert.ToInt32(goldIncomeText.text)) - val * AgeConfig.armyCostValue;
            goldIncomeText.text = goldIncome.ToString();
        }

        public static void GoldChange(int val)
        {
            goldValue = (Convert.ToInt32(goldValueText.text) + val);
            goldValueText.text = goldValue.ToString();
        }

        public static void GoldIncomeChange(int val)
        {
            goldIncome = (Convert.ToInt32(goldIncomeText.text)) + val;
            goldIncomeText.text = goldIncome.ToString();
        }

        public static void HappinessChange(int val)
        {
            happyValue = (Convert.ToInt32(happyValueText.text) + val);
            happyValueText.text = happyValue.ToString();
        }

        public static void PeopleChange(int val)
        {
            peopleValue = Convert.ToInt32(peopleValueText.text) + val;
            peopleValueText.text = peopleValue.ToString();

            foodIncome = Convert.ToInt32(foodIncomeText.text) - val;
            foodIncomeText.text = foodIncome.ToString();
        }

        public static void EvolutionChange(int val)
        {
            evolutionValue = Convert.ToInt32(evolutionValueText.text) + val;
            evolutionValueText.text = evolutionValue.ToString();
        }

        //########################################################################################

        public static void GoldenAge()
        {
            goldValue = (Convert.ToInt32(goldValueText.text) + peopleValue);
            goldValueText.text = goldValue.ToString();
        }

        public static void FoodGoldenAge()
        {
            foodIncome = Convert.ToInt32(foodIncomeText.text) + evolutionValue;
            foodIncomeText.text = foodIncome.ToString();
        }

    }
}