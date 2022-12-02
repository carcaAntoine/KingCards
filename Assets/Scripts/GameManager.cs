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
        int malusIndex = 0;
        int minIndex = 0;
        public int numberOfCards; //Nombre de cartes (hors cartes du turn 1)
        public GameObject Card1Object; //1re carte à afficher
        public GameObject Card2Object; //2e carte à afficher

        //----------- Game Over Canvas -------------
        private GameObject gameOverScreen;
        private Text gameOverText;
        private Text scoreText;

        //------------- Malus Canvas ---------------
        private GameObject malusScreen;
        private GameObject malusCatastropheScreen;
        private GameObject malusAlerteScreen;
        private Text malusTitle;
        private Text malusDesc;
        private Image malusEffectIcon;
        private Text malusEffect;
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
            //UIManager.uiManagerSingleton.DisplayTurnOneCards();
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
            malusTitle = GameObject.Find("MalusTitle").GetComponent<Text>();
            malusDesc = GameObject.Find("Malus").GetComponent<Text>();
            malusEffectIcon = GameObject.Find("IconMalus").GetComponent<Image>();
            malusEffect = GameObject.Find("MalusEffect").GetComponent<Text>();
            malusCatastropheScreen = GameObject.Find("background catastrophe");
            malusAlerteScreen = GameObject.Find("background");
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

                    //minIndex = 10;
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
            cardSlots[1].GetComponent<Cards>().Configure(cardCreator.OtherTurnsCards[card2Index]);
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
            //Debug.Log("minIndex : " + minIndex);
            System.Random rdn = new System.Random();
            malusIndex = rdn.Next(minIndex, malusListLength - 1);
            Debug.Log("malus choisi : " + malusIndex);

            //affichage du malus
            malusTitle.text = malusCreator.MalusList[malusIndex].alertLevel;
            malusDesc.text = malusCreator.MalusList[malusIndex].malusDescription;
            malusEffectIcon.sprite = malusCreator.MalusList[malusIndex].malusSprite;
            malusEffect.text = malusCreator.MalusList[malusIndex].malusEffectText;

            switch (malusTitle.text)
            {
                case "Alerte !":
                    malusScreen.SetActive(true);
                    malusAlerteScreen.SetActive(true);
                    malusCatastropheScreen.SetActive(false);
                    break;
                case "Catastrophe !":
                    malusScreen.SetActive(true);
                    malusCatastropheScreen.SetActive(true);
                    malusAlerteScreen.SetActive(false);
                    break;
                default:
                    Debug.Log("erreur, mauvais titre");
                    break;
            }

            string nameMalus = malusCreator.MalusList[malusIndex].malusName;
            Debug.Log("Malus name : " + nameMalus);

            //application du malus
            CardManager.InitValues();
            switch (nameMalus)
            {
                //------------------------- ALERTES -------------------------
                case "AttaqueBarbare":
                    CardManager.armyValue = CardManager.armyValue - 20;
                    CardManager.armyValueText.text = CardManager.armyValue.ToString();
                    break;
                case "IncendieDepotGrains":
                    CardManager.foodValue = CardManager.foodValue - 30;
                    CardManager.foodValueText.text = CardManager.foodValue.ToString();
                    break;
                case "Voleur":
                    CardManager.goldValue = CardManager.goldValue - 30;
                    CardManager.goldValueText.text = CardManager.goldValue.ToString();
                    break;
                case "Kidnapping":
                    CardManager.peopleValue = CardManager.peopleValue - 3;
                    CardManager.peopleValueText.text = CardManager.peopleValue.ToString();
                    break;
                case "Mécontents":
                    CardManager.happyValue = CardManager.happyValue - 5;
                    CardManager.happyValueText.text = CardManager.happyValue.ToString();
                    break;
                case "ProtectionRoutes":
                    CardManager.armyValue = CardManager.armyValue - 10;
                    CardManager.armyValueText.text = CardManager.armyValue.ToString();
                    break;
                case "MauvaisesRécoltes":
                    CardManager.foodValue = CardManager.foodValue - 50;
                    CardManager.foodValueText.text = CardManager.foodValue.ToString();
                    break;
                case "Travaux":
                    CardManager.goldValue = CardManager.goldValue - 60;
                    CardManager.goldValueText.text = CardManager.goldValue.ToString();
                    break;
                case "Accident":
                    CardManager.peopleValue = CardManager.peopleValue - 10;
                    CardManager.peopleValueText.text = CardManager.peopleValue.ToString();
                    break;
                case "Deuil":
                    CardManager.happyValue = CardManager.happyValue - 5;
                    CardManager.happyValueText.text = CardManager.happyValue.ToString();
                    break;
                //------------------------- CATASTROPHES -------------------------
                case "RécoltesPerdues":
                    CardManager.foodValue = CardManager.foodValue - 150;
                    CardManager.foodValueText.text = CardManager.foodValue.ToString();
                    break;
                case "Guerre":
                    CardManager.armyValue = CardManager.armyValue - 150;
                    CardManager.armyValueText.text = CardManager.armyValue.ToString();
                    break;
                case "Inondation":
                    CardManager.goldValue = CardManager.goldValue - 150;
                    CardManager.goldValueText.text = CardManager.goldValue.ToString();
                    break;
                case "Révolte":
                    CardManager.happyValue = CardManager.happyValue - 20;
                    CardManager.happyValueText.text = CardManager.happyValue.ToString();
                    break;
                case "Épidémie":
                    CardManager.peopleValue = CardManager.peopleValue / 2;
                    CardManager.peopleValueText.text = CardManager.peopleValue.ToString();
                    break;
                default:
                    Debug.Log("Erreur : Malus introuvable");
                    break;
            }


        }

        public void AddValues(Card card)
        {
            //previousTurns.Add(card);
            CardManager.InitValues();
            //Debug.Log(card.foodIncome);

            CardManager.FoodChange(card.food);
            Debug.Log("card food : " + card.food);
            CardManager.FoodIncomeChange(card.foodIncome);
            Debug.Log("card foodIncome : " + card.foodIncome);
            CardManager.ArmyChange(card.army);
            Debug.Log("card army : " + card.army);
            CardManager.GoldChange(card.gold);
            Debug.Log("card gold : " + card.gold);
            CardManager.GoldIncomeChange(card.goldIncome);
            Debug.Log("card goldIncome : " + card.goldIncome);
            CardManager.HappinessChange(card.happiness);
            Debug.Log("card happy : " + card.happiness);
            CardManager.PeopleChange(card.people);
            Debug.Log("card people : " + card.people);

        }

    }
}