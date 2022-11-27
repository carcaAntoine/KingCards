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
                case "LoiAgricoleCard":
                    CardManager.LoiAgricoleCard();
                    Debug.Log("Fin du tour 1");
                    GameManager.singleton.destroyDeck();
                    break;
                case "LoiFiscaleCard":
                    CardManager.LoiFiscaleCard();
                    GameManager.singleton.destroyDeck();
                    break;
                case "LoiMartialeCard":
                    CardManager.LoiMartialeCard();
                    GameManager.singleton.destroyDeck();
                    break;
                case "Convoi":
                    CardManager.Convoi();
                    break;
                case "Education":
                    CardManager.Education();
                    break;
                case "Impots":
                    CardManager.Impots();
                    break;
                case "JoiesDeLaRue":
                    CardManager.JoiesDeLaRue();
                    break;
                case "NouvelleTaxe":
                    CardManager.NouvelleTaxe();
                    break;
                case "Loi Fiscale":
                    Debug.Log("Hello there");
                    break;
                default:
                    Debug.Log("erreur, carte non renseignée");
                    break;
            }
            //GameManager.singleton.EndTurn();
            //GameManager.newTurn();

        }



    }
}