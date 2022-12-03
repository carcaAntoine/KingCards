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
        //string card1; //Nom de la première carte, tiré du tableau cardList
        //string card2; //Nom de la deuxième carte, tiré du tableau cardList
        public int turnCounterValue;
        public Text turnCounterText;
        int card1Index = 0;
        int card2Index = 0;
        public int CardCooldown; //Valeur du cooldown, redistribué plus tard à card1Cooldown et card2Cooldown
        int card1Cooldown;
        int card2Cooldown;
        int malusIndex = 0;
        int minIndex = 0;
        public int numberOfCards; //Nombre de cartes (hors cartes du turn 1)
        //public GameObject Card1Object; //1re carte à afficher
        //public GameObject Card2Object; //2e carte à afficher

        //----------- Game Over Canvas -------------
        private GameObject gameOverScreen;
        private Text gameOverText;
        private Text scoreText;

        //------------- Malus Canvas ---------------
        private GameObject malusScreen;
        public Malus malus;
        public GameObject[] malusSlots;
        public int malusALertLevel;
        //------------------------------------------
        public CardCreator cardCreator;
        public GameObject[] cardSlots;
        public MalusCreator malusCreator;
        public Card card;

        //------------- Pause Menu Canvas ---------------

        public GameObject pauseMenuScreen;

        //------------------------------------------

        void Awake()
        {
            singleton = this;

        }

        void Start()
        {
            InitGame();
            DisplayTurnOneCards();
        }

        void InitGame()
        {
            //----- Désactive Ecran de GameOver -----
            gameOverScreen = GameObject.Find("GameOverCanva");
            scoreText = GameObject.Find("ScoreValue").GetComponent<Text>();
            gameOverScreen.SetActive(false);

            //Initialise éléments Malus canvas et désactive Ecran Malus
            malusScreen = GameObject.Find("MalusCanvas");
            malusScreen.SetActive(false);

            //Désactive Ecran Pause
            pauseMenuScreen = GameObject.Find("PauseMenuCanvas");
            pauseMenuScreen.SetActive(false);

            turnCounterText = GameObject.Find("TurnCount").GetComponent<Text>();
            turnCounterValue = Convert.ToInt32(turnCounterText.text);
        }

        public void EndTurnOne()
        {
            numberOfCards = CardCreator.ListLength;
            Debug.Log("nombre de cartes : " + numberOfCards);
            GameObject.Find("ThirdCard").SetActive(false);
            CardManager.IncomeManager();
        }

        public void EndTurn()
        {
            CardManager.IncomeManager();
            checkIfGameIsOver();
            if (!CardManager.gameOver)
            {
                turnCounterValue += 1;
                turnCounterText.text = turnCounterValue.ToString();

                newTurn();

                if (turnCounterValue % 10 == 0)
                {
                    GameObject.Find("FirstCard").SetActive(false);
                    GameObject.Find("SecondCard").SetActive(false);

                    GetMalus();
                }

                if (turnCounterValue % 10 == 5 && turnCounterValue != 5)
                {
                    CardManager.PeopleChange(5);
                }
            }
        }

        public void newTurn()
        {
            // Création des indexs pour la sélection aléatoire des 2 cartes
            System.Random rdn = new System.Random();
            card1Index = rdn.Next(3, numberOfCards - 1);
            card2Index = rdn.Next(3, numberOfCards - 1);
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
            //Debug.Log("CheckIsGameOver activé");
            CardManager.CheckValues();
            if (CardManager.gameOver == true)
            {
                gameOverScreen.SetActive(true);
                gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();

                if (CardManager.foodValue <= 0)
                {
                    gameOverText.text = "Votre peuple est mort de faim. \n Votre règne s'achève après " + turnCounterValue + " jours.";
                }
                else if (CardManager.armyValue <= 0)
                {
                    gameOverText.text = "Votre Royaume a fini par succomber à une attaque ennemie. \n Votre règne s'achève après " + turnCounterValue + " jours.";
                }
                else if (CardManager.goldValue <= 0)
                {
                    gameOverText.text = "Votre Royaume est ruiné. \n Votre règne s'achève après " + turnCounterValue + " jours.";
                }
                else if (CardManager.peopleValue <= 0)
                {
                    gameOverText.text = "Tous vos habitants sont morts. \n Votre règne s'achève après " + turnCounterValue + " jours.";
                }
                else
                {
                    gameOverText.text = "Votre peuple vous a destitué. \n Votre règne s'achève après " + turnCounterValue + " jours.";
                }

                //Affichage du score
                int score = (CardManager.peopleValue * 3) + CardManager.happyValue + CardManager.goldValue;
                scoreText.text = score.ToString();
            }

        }

        public void DisplayTurnOneCards()
        {
            for (int i = 0; i < 3; i++)
            {
                //Assigne infos des cards de cardCreator
                cardSlots[i].GetComponent<Cards>().Configure(cardCreator.OtherTurnsCards[i]);
            }
        }

        public void DisplayCards()
        {

            cardSlots[0].GetComponent<Cards>().Configure(cardCreator.OtherTurnsCards[card1Index]);
            card1Cooldown = CardCooldown;
            Debug.Log("card 1 cooldown : " + card1Cooldown);
            cardSlots[1].GetComponent<Cards>().Configure(cardCreator.OtherTurnsCards[card2Index]);
            card2Cooldown = CardCooldown;
            Debug.Log("card 2 cooldown : " + card2Cooldown);
        }

        public void DisplayMalus()
        {
            malusSlots[malusALertLevel].GetComponent<MalusConfig>().ConfigureMalus(malusCreator.MalusList[malusIndex]);
        }

        public void GetMalus()
        {
            //augmentation de la difficulté au-delà du tour 50
            if (turnCounterValue == 50)
            {
                minIndex = 10;
            }

            //choix aléatoire de l'index du malus
            int malusListLength = MalusCreator.mlLength;
            System.Random rdn = new System.Random();
            malusIndex = rdn.Next(minIndex, malusListLength - 1);

            malusScreen.SetActive(true);
            if (malusCreator.MalusList[malusIndex].alertLevel == 0)
            {
                malusALertLevel = 0;
                malusSlots[0].SetActive(true);
                malusSlots[1].SetActive(false);
            }
            else
            {
                malusALertLevel = 1;
                malusSlots[0].SetActive(false);
                malusSlots[1].SetActive(true);
            }

            DisplayMalus();

            string nameMalus = malusCreator.MalusList[malusIndex].malusName;
            Debug.Log("Malus name : " + nameMalus);
        }

        

        public void AddValues(Card card)
        {
            //previousTurns.Add(card);
            CardManager.InitValues();

            CardManager.FoodChange(card.food);
            CardManager.FoodIncomeChange(card.foodIncome);
            CardManager.ArmyChange(card.army);
            CardManager.GoldChange(card.gold);
            CardManager.GoldIncomeChange(card.goldIncome);
            CardManager.HappinessChange(card.happiness);
            CardManager.PeopleChange(card.people);
        }

    }
}