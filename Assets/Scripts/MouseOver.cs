using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace MyGame
{
    public class MouseOver : MonoBehaviour
    {
        private string selectionnedCard;//Nom de la carte (GameObject) sélectionnée
        private string cardName; //Nom de la carte sélectionnée
        //private string functionName;//Nom de la fonction liée à la carte sélectionnée


        private void OnMouseDown()
        {
            selectionnedCard = this.gameObject.name;
            Debug.Log("clic sur " + selectionnedCard);
            cardName = GameObject.Find(selectionnedCard).transform.GetChild(2).GetComponent<Text>().text;

            Debug.Log("nom de la carte : " + cardName);
/*
            switch (cardName)
            {
                case "Loi Agricole":
                    CardManager.FoodIncomePlus(5);
                    //Debug.Log("Fin du tour 1");
                    GameManager.singleton.EndTurnOne();
                    break;
                case "Loi Fiscale":
                    CardManager.GoldIncomePlus(5);
                    GameManager.singleton.EndTurnOne();
                    break;
                case "Loi Martiale":
                    CardManager.ArmyPlus(10);
                    GameManager.singleton.EndTurnOne();
                    break;
                case "Convoi":
                    CardManager.FoodPlus(15);
                    break;
                case "Éducation":
                    CardManager.BonheurPlus(5);
                    CardManager.GoldMinus(50);
                    break;
                case "Impôts":
                    CardManager.GoldPlus(50);
                    break;
                case "Joies de la Rue":
                    CardManager.BonheurMinus(5);
                    CardManager.GoldPlus(15);
                    break;
                case "Libre Passage":
                    CardManager.PeoplePlus(5);
                    break;
                case "Joies du Cirque":
                    CardManager.BonheurPlus(10);
                    CardManager.GoldPlus(5);
                    break;
                case "L'Art des Mots":
                    CardManager.BonheurPlus(5);
                    CardManager.GoldMinus(50);
                    break;
                case "Nationalisme":
                    CardManager.ArmyPlus(5);
                    break;
                case "Nouvelle Taxe":
                    CardManager.GoldIncomePlus(2);
                    CardManager.BonheurMinus(5);
                    break;
                case "Récoltes Prometteuses":
                    CardManager.FoodIncomePlus(2);
                    break;
                case "Subventions Militaires":
                    CardManager.ArmyPlus(10);
                    break;
                case "Coupe Budgétaire":
                    CardManager.ArmyMinus(5);
                    break;
                case "Contrat Agricole":
                    CardManager.FoodIncomePlus(2);
                    CardManager.GoldIncomeMinus(2);
                    break;
                case "Contrat de Sécurité":
                    CardManager.ArmyPlus(10);
                    CardManager.GoldIncomePlus(5);
                    break;
                case "Contrat de Travail":
                    CardManager.GoldPlus(25);
                    break;
                case "Nouveaux arrivants":
                    CardManager.PeoplePlus(7);
                    break;
                case "Heureuse arrivée":
                    CardManager.PeoplePlus(10);
                    CardManager.FoodIncomePlus(15);
                    break;
                case "Festival":
                    CardManager.BonheurPlus(10);
                    CardManager.GoldMinus(35);
                    break;
                case "Parade militaire":
                    CardManager.BonheurPlus(5);
                    CardManager.GoldMinus(20);
                    break;
                case "Projet militaire":
                    CardManager.ArmyPlus(15);;
                    break;
                default:
                    Debug.Log("erreur, carte non renseignée");
                    break;
            }
            */
            //GameManager.singleton.AddValues(card);
            GameManager.singleton.EndTurn();


        }



    }
}