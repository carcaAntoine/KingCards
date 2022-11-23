using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class MouseOver : MonoBehaviour
    {
        private string selectionnedCard;//Nom de la carte sélectionnée
        private string functionName;//Nom de la fonction liée à la carte sélectionnée

        private void OnMouseDown()
        {
            selectionnedCard = this.gameObject.name;
            Debug.Log("clic sur " + selectionnedCard);// retourne NameCard(Clone)

            //########## Supprimer le (Clone) de selectionnedCard ##########
            if (GameManager.turnCounterValue == 1)
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
                    GameManager.destroyDeck();
                    break;
                case "LoiFiscaleCard":
                    CardManager.LoiFiscaleCard();
                    GameManager.destroyDeck();
                    break;
                case "LoiMartialeCard":
                    CardManager.LoiMartialeCard();
                    GameManager.destroyDeck();
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
            GameManager.EndTurn();
            //GameManager.newTurn();

        }



    }
}