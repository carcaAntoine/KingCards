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

            switch (cardName)
            {
                case "Loi Agricole":
                    CardManager.LoiAgricoleCard();
                    Debug.Log("Fin du tour 1");
                    GameManager.singleton.EndTurnOne();
                    break;
                case "Loi Fiscale":
                    CardManager.LoiFiscaleCard();
                    GameManager.singleton.EndTurnOne();
                    break;
                case "Loi Martiale":
                    CardManager.LoiMartialeCard();
                    GameManager.singleton.EndTurnOne();
                    break;
                case "Convoi":
                    CardManager.Convoi();
                    break;
                case "Éducation":
                    CardManager.Education();
                    break;
                case "Impôts":
                    CardManager.Impots();
                    break;
                case "Joies de la Rue":
                    CardManager.JoiesDeLaRue();
                    break;
                case "Libre Passage":
                    CardManager.LibrePassage();
                    break;
                case "Joies du Cirque":
                    CardManager.JoiesDuCirque();
                    break;
                case "L'Art des Mots":
                    CardManager.LartDesMots();
                    break;
                case "Nationalisme":
                    CardManager.Nationalisme();
                    break;
                case "Nouvelle Taxe":
                    CardManager.NouvelleTaxe();
                    break;
                case "Récoltes Prometteuses":
                    CardManager.RecoltesPrometteuses();
                    break;
                default:
                    Debug.Log("erreur, carte non renseignée");
                    break;
            }
            GameManager.singleton.EndTurn();


        }



    }
}