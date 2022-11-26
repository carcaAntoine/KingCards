using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class MouseOver : MonoBehaviour
    {
        private string selectionnedCard;//Nom de la carte sélectionnée
        private string functionName;//Nom de la fonction liée à la carte sélectionnée

        private void OnMouseEnter()
        {
            selectionnedCard = this.gameObject.name;
            Debug.Log("survol de " + selectionnedCard);
        }

        private void OnMouseHover()
        {
            selectionnedCard = this.gameObject.name;
            Debug.Log("le survol de " + selectionnedCard);
        }

        private void OnMouseDown()
        {
            selectionnedCard = this.gameObject.name;
            Debug.Log("clic sur " + selectionnedCard);// retourne NameCard(Clone)

            //########## Supprimer le (Clone) de selectionnedCard ##########
            if (GameManager.singleton.turnCounterValue == 1)
            {
                int len = 7; //nombre de caractères à supprimer à la fin de selectionnedCard
                functionName = selectionnedCard.RemoveCloneEnd(len);
                Debug.Log(functionName);
            }
            else
            {
                functionName = selectionnedCard;
                Debug.Log("functionName : " + functionName);
            }
            //##############################################################

            switch (functionName)
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
                default:
                    Debug.Log("erreur, carte non renseignée");
                    break;
            }
            GameManager.singleton.EndTurn();
            //GameManager.newTurn();

        }



    }
}