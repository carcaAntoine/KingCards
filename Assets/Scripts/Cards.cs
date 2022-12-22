using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace MyGame
{
    public class Cards : MonoBehaviour
    {
        public Card card;
        public Card myCard;
        private string selectionnedCard;//Nom de la carte (GameObject) sélectionnée
        private string cardName; //Nom de la carte sélectionnée
        public static bool turnone = true;

        public void Configure(Card card)
        {
            transform.GetChild(1).GetComponent<Image>().sprite = card.signetSprite;
            transform.GetChild(2).GetComponent<Text>().text = card.cardTitle;
            transform.GetChild(3).GetComponent<Text>().text = card.cardDescription;
            transform.GetChild(4).GetComponent<Image>().sprite = card.effect1Sprite;
            transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = card.effect1Text;
            transform.GetChild(5).GetComponent<Image>().sprite = card.effect2Sprite;
            transform.GetChild(5).transform.GetChild(0).GetComponent<Text>().text = card.effect2Text;
            myCard = card; // permet de faire le AddValue() dans la fonction OnMouseDown
            //GameManager.singleton.CardCooldown = card.cooldown;
            
        }

        private void OnMouseEnter()
        {
            transform.GetComponent<RectTransform>().localScale = new Vector3(1.05f, 1.05f, 1f);
            //transform.GetComponent<RectTransform>().rotation = new Vector3(0, 0, 3);
            transform.Rotate(0f, 0f, 1f);
            GameManager.singleton.cardSound.Play();
        }

        private void OnMouseExit()
        {
            transform.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            transform.Rotate(0f, 0f, -1f);
        }

        private void OnMouseDown()
        {
            selectionnedCard = this.gameObject.name;
            //Debug.Log("clic sur " + selectionnedCard);
            cardName = GameObject.Find(selectionnedCard).transform.GetChild(2).GetComponent<Text>().text;
            Debug.Log("nom de la carte : " + cardName);

            myCard.cooldown = 6;
            GameManager.singleton.AddValues(myCard);

            if (turnone)
            {
                GameManager.singleton.EndTurnOne();
                turnone = false;
            }
            else
            {
                GameManager.singleton.EndTurn();
            }

            GameManager.singleton.NewTurn();
        }
    }
}