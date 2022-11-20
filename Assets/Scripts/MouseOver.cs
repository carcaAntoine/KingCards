using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class MouseOver : GameManager
    {
        private string selectionnedCard;//Nom de la carte sélectionnée
        private string functionName;//Nom de la fonction liée à la carte sélectionnée

        private void OnMouseDown()
        {
            selectionnedCard = this.gameObject.name;
            Debug.Log("clic sur " + selectionnedCard);// retourne NameCard(Clone)

            //########## Supprimer le (Clone) de selectionnedCard ##########

            int len = 7; //nombre de caractères à supprimer à la fin de selectionnedCard
            functionName = selectionnedCard.RemoveCloneEnd(len);
            Debug.Log(functionName);

            //##############################################################

            switch (functionName)
            {
                case "LoiAgricoleCard":
                    CardManager.LoiAgricoleCard();
                    EndTurn();
                    Debug.Log("Fin du tour 1");
                    newTurn();
                    break;
                case "LoiFiscaleCard":
                    CardManager.LoiFiscaleCard();
                    break;
                case "LoiMartialeCard":
                    CardManager.LoiMartialeCard();
                    break;
                default:
                    Debug.Log("error");
                    break;
            }


        }



    }
}