using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


namespace MyGame
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager singleton;
        string card1; //Nom de la première carte, tiré du tableau cardList
        string card2; //Nom de la deuxième carte, tiré du tableau cardList
        public int turnCounterValue;
        public Text turnCounterText;
        int card1Index = 0;
        int card2Index = 0;
        public int numberOfCards; //Nombre de cartes (hors cartes du turn 1)
        public GameObject Card1Object; //1re carte à afficher
        public GameObject Card2Object; //2e carte à afficher
        private GameObject gameOverScreen;
        private Text gameOverText;

        public CardCreator cardCreator;
        public GameObject[] cardSlots;


        //------------------------------------------

        void Awake()
        {
            singleton = this;
        }

        void Start()
        {
            InitGame();
            //UIManager.uiManagerSingleton.DisplayTurnOneCards();
            DisplayTurnOneCards();
        }

        void InitGame()
        {
            //----- Désactive Ecran de GameOver -----
            gameOverScreen = GameObject.Find("GameOverCanva");
            gameOverScreen.SetActive(false);

            turnCounterText = GameObject.Find("TurnCount").GetComponent<Text>();
            turnCounterValue = Convert.ToInt32(turnCounterText.text);
        }

        public void EndTurnOne()
        {
            numberOfCards = CardCreator.ListLength;
            Debug.Log("nombre de cartes : " + numberOfCards);
            GameObject.Find("ThirdCard").SetActive(false);
        }

        public void EndTurn()
        {
            checkIfGameIsOver();
            if (!CardManager.gameOver)
            {
                turnCounterValue += 1;
                turnCounterText.text = turnCounterValue.ToString();

                //Debug.Log("EndTurn appelé");
                newTurn();
            }
        }

        public void newTurn()
        {
            // Création des indexs pour la sélection aléatoire des 2 cartes
            System.Random rdn = new System.Random();
            card1Index = rdn.Next(0, numberOfCards - 1);
            card2Index = rdn.Next(0, numberOfCards - 1);
            while (card1Index == card2Index)
            {
                card2Index = rdn.Next(0, numberOfCards);
                Debug.Log("valeurs identiques. Nouvel essai");
            }
            Debug.Log("card1Index : " + card1Index);
            Debug.Log("card2Index : " + card2Index);
            // ------------------------------------------------------------

            DisplayCards();
        }

        public void checkIfGameIsOver()
        {
            CardManager.CheckValues();
            if (CardManager.gameOver == true)
            {
                gameOverScreen.SetActive(true);
                gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();

                if (CardManager.foodValue <= 0)
                {
                    gameOverText.text = "Votre peuple est mort de faim. \n Votre règne s'achève après " + turnCounterValue + " ans.";
                }
                else if (CardManager.goldValue <= 0)
                {
                    gameOverText.text = "Votre Royaume est ruiné. \n Votre règne s'achève après " + turnCounterValue + " ans.";
                }
                else if (CardManager.peopleValue <= 0)
                {
                    gameOverText.text = "Tous vos habitants sont morts. \n Votre règne s'achève après " + turnCounterValue + " ans.";
                }
                else
                {
                    gameOverText.text = "Votre peuple vous a destitué. \n Votre règne s'achève après " + turnCounterValue + " ans.";
                }

            }

        }

        public void DisplayTurnOneCards()
        {
            for (int i = 0; i < cardCreator.TurnOneCards.Count; i++)
            {
                //Assigne infos des cards de cardCreator

                cardSlots[i].transform.GetChild(1).GetComponent<Image>().sprite = cardCreator.TurnOneCards[i].signetSprite;
                cardSlots[i].transform.GetChild(2).GetComponent<Text>().text = cardCreator.TurnOneCards[i].cardTitle;
                cardSlots[i].transform.GetChild(3).GetComponent<Text>().text = cardCreator.TurnOneCards[i].cardDescription;
                cardSlots[i].transform.GetChild(4).GetComponent<Image>().sprite = cardCreator.TurnOneCards[i].effect1Sprite;
                cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = cardCreator.TurnOneCards[i].effect1Text;
                cardSlots[i].transform.GetChild(5).GetComponent<Image>().sprite = cardCreator.TurnOneCards[i].effect2Sprite;
                cardSlots[i].transform.GetChild(5).transform.GetChild(0).GetComponent<Text>().text = cardCreator.TurnOneCards[i].effect2Text;
            }
        }

        public void DisplayCards()
        {
            cardSlots[0].transform.GetChild(1).GetComponent<Image>().sprite = cardCreator.OtherTurnsCards[card1Index].signetSprite;
            cardSlots[0].transform.GetChild(2).GetComponent<Text>().text = cardCreator.OtherTurnsCards[card1Index].cardTitle;
            cardSlots[0].transform.GetChild(3).GetComponent<Text>().text = cardCreator.OtherTurnsCards[card1Index].cardDescription;
            cardSlots[0].transform.GetChild(4).GetComponent<Image>().sprite = cardCreator.OtherTurnsCards[card1Index].effect1Sprite;
            cardSlots[0].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = cardCreator.OtherTurnsCards[card1Index].effect1Text;
            cardSlots[0].transform.GetChild(5).GetComponent<Image>().sprite = cardCreator.OtherTurnsCards[card1Index].effect2Sprite;
            cardSlots[0].transform.GetChild(5).transform.GetChild(0).GetComponent<Text>().text = cardCreator.OtherTurnsCards[card1Index].effect2Text;

            cardSlots[1].transform.GetChild(1).GetComponent<Image>().sprite = cardCreator.OtherTurnsCards[card2Index].signetSprite;
            cardSlots[1].transform.GetChild(2).GetComponent<Text>().text = cardCreator.OtherTurnsCards[card2Index].cardTitle;
            cardSlots[1].transform.GetChild(3).GetComponent<Text>().text = cardCreator.OtherTurnsCards[card2Index].cardDescription;
            cardSlots[1].transform.GetChild(4).GetComponent<Image>().sprite = cardCreator.OtherTurnsCards[card2Index].effect1Sprite;
            cardSlots[1].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = cardCreator.OtherTurnsCards[card2Index].effect1Text;
            cardSlots[1].transform.GetChild(5).GetComponent<Image>().sprite = cardCreator.OtherTurnsCards[card2Index].effect2Sprite;
            cardSlots[1].transform.GetChild(5).transform.GetChild(0).GetComponent<Text>().text = cardCreator.OtherTurnsCards[card2Index].effect2Text;
        }
    }
}