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
        static private int foodValue;  //valeur de la nourriture à ajouter
        static private int foodIncome; //valeur de l'income à ajouter

        /*------------------ ARMEE ------------------*/
        static private Text armyValueText; //valeur armée (GameObject)
        static private int armyValue; //valeur armée à ajouter

        /*------------------ ARGENT ------------------*/
        static private Text goldIncomeText; //income argent (GameObject)
        static private Text goldValueText;  //valeur argent (GameObject)
        static private int goldValue;  //valeur de l'argent à ajouter
        static private int goldIncome; //valeur de l'income à ajouter
        
        /*--------------------------------------------*/
        void Start()
        {

        }

        void Update()
        {

        }

        static public void LoiAgricoleCard()
        {
            foodIncomeText = GameObject.Find("FoodIncome").GetComponent<Text>();
            foodIncome = Convert.ToInt32(foodIncomeText.text);
            foodIncomeText.text = (foodIncome + 5).ToString();

        }

        static public void LoiFiscaleCard()
        {
            goldIncomeText = GameObject.Find("GoldIncome").GetComponent<Text>();
            goldIncome = Convert.ToInt32(goldIncomeText.text);
            goldIncomeText.text = (goldIncome + 5).ToString();
        }

        static public void LoiMartialeCard()
        {
            armyValueText = GameObject.Find("ArmyValue").GetComponent<Text>();
            armyValue = Convert.ToInt32(armyValueText.text);
            armyValueText.text = (armyValue + 50).ToString();
        }
    }
}