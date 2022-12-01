using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace MyGame
{
    public class Cards : MonoBehaviour
    {
        public Card card;
        private string selectionnedCard;//Nom de la carte (GameObject) sélectionnée
        private string cardName; //Nom de la carte sélectionnée

        public void Configure(Card card)
        {
            transform.GetChild(1).GetComponent<Image>().sprite = card.signetSprite;
            transform.GetChild(2).GetComponent<Text>().text = card.cardTitle;
            transform.GetChild(3).GetComponent<Text>().text = card.cardDescription;
            transform.GetChild(4).GetComponent<Image>().sprite = card.effect1Sprite;
            transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = card.effect1Text;
            transform.GetChild(5).GetComponent<Image>().sprite = card.effect2Sprite;
            transform.GetChild(5).transform.GetChild(0).GetComponent<Text>().text = card.effect2Text;
            Debug.Log("foodIncome : " + card.foodIncome);

        }

        

        private void OnMouseDown()
        {
            selectionnedCard = this.gameObject.name;
            //Debug.Log("clic sur " + selectionnedCard);
            cardName = GameObject.Find(selectionnedCard).transform.GetChild(2).GetComponent<Text>().text;

            Debug.Log("nom de la carte : " + cardName);
            //Debug.Log("foodIncome : " + card.foodIncome);
            
            GameManager.singleton.AddValues(card);
            GameManager.singleton.EndTurnOne();
            GameManager.singleton.newTurn();
        }
    }
}