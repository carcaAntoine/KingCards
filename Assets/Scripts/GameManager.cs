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
        [HideInInspector]
        public int turnCounterValue;
        [HideInInspector]
        public Text turnCounterText;
        int card1Index = 0;
        int card2Index = 0;
        int malusIndex = 0;
        int minIndex = 0;
        [HideInInspector]
        public int numberOfCards; //Nombre de cartes (hors cartes du turn 1)

        //----------- Game Over Canvas -------------
        private GameObject gameOverScreen;
        private Text gameOverText;
        private Text scoreText;

        //------------- Malus Canvas ---------------
        private GameObject malusScreen;
        [HideInInspector]
        public Malus malus;
        public MalusCreator malusCreator;
        public GameObject[] malusSlots;
        [HideInInspector]
        public int malusAlertLevel;
        //------------------------------------------
        public CardCreator cardCreator;
        public GameObject[] cardSlots;
        [HideInInspector]
        public Card card;

        //------------- Pause Menu Canvas ---------------
        [HideInInspector]
        public GameObject pauseMenuScreen;

        //------------ Nouvelle Ère Canvas --------------
        [HideInInspector]
        public GameObject newAgeScreen;
        public AgeCreator ageCreator;
        public GameObject agePrefab;
        [HideInInspector]
        public AgeConfig ageConfig;

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

            //Désactive Ecran Nouvelle Ere
            newAgeScreen = GameObject.Find("NewAgeCanvas");
            newAgeScreen.SetActive(false);

            turnCounterText = GameObject.Find("TurnCount").GetComponent<Text>();
            turnCounterValue = Convert.ToInt32(turnCounterText.text);
        }

        public void EndTurnOne()
        {
            numberOfCards = CardCreator.ListLength;
            Debug.Log("nombre de cartes : " + numberOfCards);
            GameObject.Find("ThirdCard").SetActive(false);
            turnCounterValue += 1;
            turnCounterText.text = turnCounterValue.ToString();
            CardManager.IncomeManager();
        }

        public void EndTurn()
        {
            CardManager.IncomeManager();
            CheckIfGameIsOver();
            if (!CardManager.gameOver)
            {
                turnCounterValue += 1;
                turnCounterText.text = turnCounterValue.ToString();
                //Gère le CoolDown des Cards
                for (int i = 3; i < cardCreator.OtherTurnsCards.Count - 1; i++)
                {
                    if (cardCreator.OtherTurnsCards[i].cooldown > 0)
                    {
                        cardCreator.OtherTurnsCards[i].cooldown -= 1;
                    }
                }
                //Gère l'activation du Malus
                if (turnCounterValue % 10 == 0 && turnCounterValue % 15 != 0)
                {
                    GameObject.Find("FirstCard").SetActive(false);
                    GameObject.Find("SecondCard").SetActive(false);

                    GetMalus();
                }
                //Gère l'activation d'une Nouvelle Ère
                if (turnCounterValue % 15 == 0)
                {
                    GameObject.Find("FirstCard").SetActive(false);
                    GameObject.Find("SecondCard").SetActive(false);

                    newAgeScreen.SetActive(true);
                    DisplayNewAge();
                }
                //Gère l'ajout naturel d'habitants
                if (AgeConfig.actualAgeNumber == 3)
                {
                    CardManager.PeopleChange(AgeConfig.peopleAdd);
                }
                else
                {
                    if (turnCounterValue % 10 == 5 && turnCounterValue != 5)
                    {
                        CardManager.PeopleChange(AgeConfig.peopleAdd);
                    }
                }

            }
        }

        public void NewTurn()
        {
            // Création des indexs pour la sélection aléatoire des 2 cartes
            System.Random rdn = new System.Random();
            card1Index = rdn.Next(AgeConfig.minCardIndex, AgeConfig.maxCardIndex);
            card2Index = rdn.Next(AgeConfig.minCardIndex, AgeConfig.maxCardIndex);

            Debug.Log("card1Index : " + card1Index);
            Debug.Log("card2Index : " + card2Index);

            while (cardCreator.OtherTurnsCards[card1Index].cooldown > 0)
            {
                Debug.Log("Card 1 en Cooldown. Nouvel essai");
                card1Index = rdn.Next(AgeConfig.minCardIndex, AgeConfig.maxCardIndex);
                Debug.Log("card1Index : " + card1Index);
            }

            while (cardCreator.OtherTurnsCards[card2Index].cooldown > 0)
            {
                Debug.Log("Card 2 en Cooldown. Nouvel essai");
                card2Index = rdn.Next(AgeConfig.minCardIndex, AgeConfig.maxCardIndex);
                Debug.Log("card2Index : " + card2Index);
            }

            while (card1Index == card2Index)
            {
                card2Index = rdn.Next(AgeConfig.minCardIndex, AgeConfig.maxCardIndex);
                Debug.Log("valeurs identiques. Nouvel essai");
            }

            // ------------------------------------------------------------

            DisplayCards();
        }

        public void CheckIfGameIsOver()
        {
            //Debug.Log("CheckIsGameOver activé");
            CardManager.CheckValues();
            if (CardManager.gameOver == true)
            {
                gameOverScreen.SetActive(true);
                gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();

                if (CardManager.foodValue <= 0)
                {
                    gameOverText.text = "Votre peuple est mort de faim. \n Votre Royaume s'éteint après " + turnCounterValue + " ans.";
                }
                else if (CardManager.armyValue <= 0)
                {
                    gameOverText.text = "Votre Royaume a fini par succomber à une attaque ennemie. \n Votre Royaume s'éteint après " + turnCounterValue + " ans.";
                }
                else if (CardManager.goldValue <= 0)
                {
                    gameOverText.text = "Votre Royaume est ruiné. \n Votre Royaume s'éteint après " + turnCounterValue + " ans.";
                }
                else if (CardManager.peopleValue <= 0)
                {
                    gameOverText.text = "Tous vos habitants sont morts. \n Votre Royaume s'éteint après " + turnCounterValue + " ans.";
                }
                else
                {
                    gameOverText.text = "Votre peuple vous a destitué. \n Votre Royaume s'éteint après " + turnCounterValue + " ans.";
                }

                //Affichage du score
                int score = (CardManager.peopleValue * 3) + CardManager.happyValue + CardManager.goldValue;
                scoreText.text = score.ToString();

                //Réinitialisation des stats
                CardManager.foodValueText.text = "50";
                CardManager.foodIncomeText.text = "5";
                CardManager.armyValueText.text = "30";
                CardManager.goldValueText.text = "100";
                CardManager.goldIncomeText.text = "10";
                CardManager.happyValueText.text = "10";
                CardManager.peopleValueText.text = "50";
                CardManager.gameOver = false;
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

        public void DisplayNewAge()
        {
            Debug.Log("Actual Age : " + AgeConfig.actualAgeNumber);
            agePrefab.GetComponent<AgeConfig>().ConfigureAge(ageCreator.AgeList[AgeConfig.actualAgeNumber]);
        }

        public void DisplayMalus()
        {
            malusSlots[malusAlertLevel].GetComponent<MalusConfig>().ConfigureMalus(malusCreator.MalusList[malusIndex]);
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
                malusAlertLevel = 0;
                malusSlots[0].SetActive(true);
                malusSlots[1].SetActive(false);
            }
            else
            {
                malusAlertLevel = 1;
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