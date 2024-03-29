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
        private int numberOfGames; //Nombre de parties jouées
        private int numberOfCatastrophes; //Nombre de catastrophes subies

        //----------- Game Over Canvas -------------
        private GameObject gameOverScreen;
        private Text gameOverText;
        private Text scoreText;
        private Text highScoreText;
        private int score;

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
        [HideInInspector]
        public GameObject cardsPanel;

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

        //---------------- Rules Canvas -----------------
        [HideInInspector]
        public GameObject rulesScreen;

        //------------------------------------------
        [HideInInspector]
        public GameObject evolutionStat;
        public bool evolutionIsActive;

        [HideInInspector]
        public Color evolutionColor = Color.black;

        //-------------- Sound Effects -----------------
        public AudioSource cardSound;
        public AudioSource backgroundGameMusic;
        public AudioSource gameOverMusic;
        public AudioSource newAgeSound;
        public AudioSource alertSound;
        public AudioSource catastropheSound;

        //------------------------------------------
        private GameObject firstCard;
        private GameObject secondCard;

        //------------------------------------------

        void Awake()
        {
            singleton = this;
        }

        void Start()
        {
            evolutionColor.a = 0.3f;
            InitGame();
            DisplayTurnOneCards();
        }

        void InitGame()
        {

            cardsPanel = GameObject.Find("CardsCanvas");

            //----- Désactive Ecran de GameOver -----
            gameOverScreen = GameObject.Find("GameOverCanva");
            scoreText = GameObject.Find("ScoreValue").GetComponent<Text>();
            highScoreText = GameObject.Find("HighScoreValue").GetComponent<Text>();
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

            //Désctive Ecran Règles
            rulesScreen = GameObject.Find("RulesCanvas");
            rulesScreen.SetActive(false);

            //Désactive Icon Evolution
            evolutionStat = GameObject.Find("Evolution");
            evolutionStat.transform.GetComponent<Image>().color = evolutionColor;
            evolutionStat.transform.GetChild(0).GetComponent<Text>().color = evolutionColor;

            turnCounterText = GameObject.Find("TurnCount").GetComponent<Text>();
            turnCounterValue = Convert.ToInt32(turnCounterText.text);

            firstCard = GameObject.Find("FirstCard");
            secondCard = GameObject.Find("SecondCard");


            Cards.turnone = true;
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
                if (turnCounterValue % 15 == 0 && turnCounterValue <= 75)
                {
                    GameObject.Find("FirstCard").SetActive(false);
                    GameObject.Find("SecondCard").SetActive(false);

                    newAgeScreen.SetActive(true);
                    DisplayNewAge();
                }
                //Gère l'ajout naturel d'habitants
                if (AgeConfig.actualAgeNumber == 3 && turnCounterValue % 2 == 0)
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

                //Gestion Trophées
                if (turnCounterValue == 50 && !PlayerPrefs.HasKey("50Tours"))
                {
                    PlayerPrefs.SetInt("50Tours", 1);
                }
                if (turnCounterValue == 75 && !PlayerPrefs.HasKey("Empire"))
                {
                    PlayerPrefs.SetInt("Empire", 1);
                }
                if (turnCounterValue == 100 && !PlayerPrefs.HasKey("OldKing"))
                {
                    PlayerPrefs.SetInt("OldKing", 1);
                }
                if (CardManager.goldValue >= 1000 && !PlayerPrefs.HasKey("Tresor"))
                {
                    PlayerPrefs.SetInt("Tresor", 1);
                }
                if (CardManager.foodValue >= 1000 && !PlayerPrefs.HasKey("Festin"))
                {
                    PlayerPrefs.SetInt("Festin", 1);
                }
                if (CardManager.peopleValue >= 150 && !PlayerPrefs.HasKey("Population"))
                {
                    PlayerPrefs.SetInt("Population", 1);
                }
                if (CardManager.evolutionValue >= 5 && !PlayerPrefs.HasKey("Evolution"))
                {
                    PlayerPrefs.SetInt("Evolution", 1);
                }


                //Active la stat d'Evolution
                if (turnCounterValue == 60)
                {
                    evolutionStat.transform.GetComponent<Image>().color = Color.black;
                    evolutionStat.transform.GetChild(0).GetComponent<Text>().color = Color.black;
                    evolutionIsActive = true;
                }

            }
        }

        public void NewTurn()
        {
            // Création des indexs pour la sélection aléatoire des 2 cartes
            System.Random rdn = new System.Random();
            card1Index = rdn.Next(AgeConfig.minCardIndex, AgeConfig.maxCardIndex);
            card2Index = rdn.Next(AgeConfig.minCardIndex, AgeConfig.maxCardIndex);

            //Debug.Log("minindex : " + AgeConfig.minCardIndex);
            //Debug.Log("maxindex : " + AgeConfig.maxCardIndex);

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
                //Gestion Trophée
                if (turnCounterValue == 10 && !PlayerPrefs.HasKey("10Tours"))
                {
                    PlayerPrefs.SetInt("10Tours", 1);
                }

                if (!PlayerPrefs.HasKey("NbrParties")) //Si c'est la première partie
                {
                    PlayerPrefs.SetInt("HighScore", 0);
                    PlayerPrefs.SetInt("NbrParties", 1);
                }
                else
                {
                    numberOfGames = PlayerPrefs.GetInt("NbrParties");
                    Debug.Log("Tu as joué " + numberOfGames + " partie(s).");
                    PlayerPrefs.SetInt("NbrParties", numberOfGames + 1);

                    if (numberOfGames == 10)
                    {
                        PlayerPrefs.SetInt("10Parties", 1);
                    }

                }
                //---------------

                gameOverScreen.SetActive(true);
                cardsPanel.SetActive(false);
                gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
                backgroundGameMusic.Pause();
                gameOverMusic.Play();

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
                if (evolutionIsActive)
                {
                    score = (CardManager.peopleValue * 3) + CardManager.happyValue + (CardManager.evolutionValue * 5);
                    scoreText.text = score.ToString();
                }
                else
                {
                    score = (CardManager.peopleValue * 3) + CardManager.happyValue;
                    scoreText.text = score.ToString();
                }
                if(score > PlayerPrefs.GetInt("HighScore"))
                {
                    PlayerPrefs.SetInt("HighScore", score);
                }

                highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();


                //Réinitialisation des stats
                CardManager.foodValueText.text = "50";
                CardManager.foodIncomeText.text = "5";
                CardManager.armyValueText.text = "30";
                CardManager.goldValueText.text = "100";
                CardManager.goldIncomeText.text = "5";
                CardManager.happyValueText.text = "10";
                CardManager.peopleValueText.text = "50";
                turnCounterText.text = "1";
                CardManager.gameOver = false;
                evolutionIsActive = false;

                AgeConfig.actualAgeNumber = 1;
                AgeConfig.armyCostValue = 1;
                AgeConfig.peopleAdd = 5;
                AgeConfig.minCardIndex = 0;
                AgeConfig.maxCardIndex = 17;
            }

        }

        public void DisplayTurnOneCards()
        {
            for (int i = 0; i < 3; i++)
            {
                //Assigne infos des cards de cardCreator
                cardSlots[i].GetComponent<Cards>().Configure(cardCreator.OtherTurnsCards[i]);
                cardSound.Play();
#if UNITY_ANDROID              
                cardSlots[i].transform.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1f);
#endif
            }
        }

        public void DisplayCards()
        {

            cardSlots[0].GetComponent<Cards>().Configure(cardCreator.OtherTurnsCards[card1Index]);
#if UNITY_STANDALONE_WIN
            cardSlots[0].transform.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            cardSlots[0].transform.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
#elif UNITY_ANDROID
            cardSlots[0].transform.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1f);
#endif

            cardSlots[1].GetComponent<Cards>().Configure(cardCreator.OtherTurnsCards[card2Index]);
#if UNITY_STANDALONE_WIN
            cardSlots[1].transform.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            cardSlots[1].transform.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
#elif UNITY_ANDROID
            cardSlots[1].transform.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1f);
#endif
        }

        public void DisplayNewAge()
        {
            Debug.Log("Actual Age : " + AgeConfig.actualAgeNumber);
            agePrefab.GetComponent<AgeConfig>().ConfigureAge(ageCreator.AgeList[AgeConfig.actualAgeNumber]);
            newAgeSound.Play();
        }

        public void DisplayMalus()
        {
            malusSlots[malusAlertLevel].GetComponent<MalusConfig>().ConfigureMalus(malusCreator.MalusList[malusIndex]);
        }

        public void GetMalus()
        {
            //augmentation de la difficulté au-delà du tour 80
            if (turnCounterValue == 80)
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
                alertSound.Play();
            }
            else
            {
                malusAlertLevel = 1;
                malusSlots[0].SetActive(false);
                malusSlots[1].SetActive(true);
                catastropheSound.Play();

                //Gestion Trophée
                if (!PlayerPrefs.HasKey("NbrCatastrophes"))
                {
                    PlayerPrefs.SetInt("NbrCatastrophes", 1);
                }
                else
                {
                    numberOfCatastrophes = PlayerPrefs.GetInt("NbrCatastrophes");
                    Debug.Log("Tu as subi " + numberOfCatastrophes + " catastrophes(s).");
                    PlayerPrefs.SetInt("NbrCatastrophes", numberOfCatastrophes + 1);

                    if (numberOfCatastrophes == 20)
                    {
                        PlayerPrefs.SetInt("Catastrophe", 1);
                    }
                }
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
            if (evolutionIsActive)
            {
                CardManager.EvolutionChange(card.evolution);
            }
            if (card.goldenAge)
            {
                Debug.Log("Golden Age !!");
                CardManager.GoldenAge();
            }
            if (card.foodGoldenAge)
            {
                Debug.Log("Food Golden Age !!");
                CardManager.FoodGoldenAge();
            }
        }

       
    }
}