using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


namespace MyGame
{
    public class GameManager : MonoBehaviour
    {
        public GameObject[] turn1Cards;
        public GameObject[] otherTurnsCards;
        static string[] cardsList = new string[] { "Convoi", "Education", "Impots", "JoiesDeLaRue", "NouvelleTaxe" };
        static string card1; //Nom de la première carte, tiré du tableau cardList
        static string card2; //Nom de la deuxième carte, tiré du tableau cardList
        static public int turnCounterValue;
        static public Text turnCounterText;
        static private GameObject deck;
        static int card1Index = 0;
        static int card2Index = 0;
        public static int numberOfCards; //Nombre de cartes (hors cartes du turn 1)
        static public GameObject Card1Object; //1re carte à afficher
        static public GameObject Card2Object; //2e carte à afficher
        private static GameObject gameOverScreen;
        private static Text gameOverText;
        public static bool gameIsOver = false; //passe à true quand la partie est perdue

        //------------------ Cards -----------------

        static private GameObject convoiCard;
        static private GameObject educationCard;
        static private GameObject impotsCard;
        static private GameObject joiesDeLaRueCard;
        static private GameObject nouvelleTaxeCard;

        //------------------------------------------

        void Start()
        {

            deck = GameObject.Find("Deck");
            numberOfCards = otherTurnsCards.Length;
            Debug.Log("Nombre de cartes : " + numberOfCards);
            InitGame();
            /*
            for (int i = 0; i < otherTurnsCards.Length; i++)
            {
                GameObject actualGameObject = otherTurnsCards[i];
                actualGameObject.GetComponent<Renderer>().enabled = false;
                actualGameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            */
            TurnOne();
        }

        void InitGame()
        {
            //----- Ecran de GameOver -----
            gameOverScreen = GameObject.Find("GameOverCanva");
            gameOverScreen.SetActive(false);

            //----- Cards -----
            convoiCard = GameObject.Find("Convoi");
            convoiCard.SetActive(false);

            educationCard = GameObject.Find("Education");
            educationCard.SetActive(false);

            impotsCard = GameObject.Find("Impots");
            impotsCard.SetActive(false);

            joiesDeLaRueCard = GameObject.Find("JoiesDeLaRue");
            joiesDeLaRueCard.SetActive(false);

            nouvelleTaxeCard = GameObject.Find("NouvelleTaxe");
            nouvelleTaxeCard.SetActive(false);
        }

        void TurnOne()
        {
            //Debug.Log("turn1Cards Length : " + turn1Cards.Length);
            //Debug.Log("otherTurnCards Length : " + otherTurnsCards.Length);
            int x = -5;
            for (int i = 0; i < turn1Cards.Length; i++)
            {
                GameObject toInstantiate = turn1Cards[i];
                GameObject instance = Instantiate(toInstantiate, new Vector3(x, 0, 0f), Quaternion.identity) as GameObject;
                instance.transform.parent = deck.transform;
                x = x + 5;
            }
            turnCounterText = GameObject.Find("TurnCount").GetComponent<Text>();
            turnCounterValue = Convert.ToInt32(turnCounterText.text);

        }

        public static void EndTurn()
        {
            checkIfGameIsOver();
            if (!gameIsOver)
            {
                turnCounterValue += 1;
                turnCounterText.text = turnCounterValue.ToString();

                if (turnCounterValue > 2)
                {
                    Card1Object.SetActive(false);
                    Card2Object.SetActive(false);
                }

                Debug.Log("EndTurn appelé");
                newTurn();
            }
        }

        public static void destroyDeck()
        {
            Destroy(GameObject.Find("Deck"), 0f);
        }

        public static void newTurn()
        {
            //Debug.Log("nombre de cartes : " + numberOfCards);

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

            // Implémentation des noms des cartes sélectionnées
            card1 = cardsList[card1Index];
            Debug.Log(card1);
            card2 = cardsList[card2Index];
            Debug.Log(card2);
            // ------------------------------------------------------------

            // Affichage des cartes sélectionnées
            switch (card1)
            {
                case "Convoi":
                    Card1Object = convoiCard;
                    break;
                case "Education":
                    Card1Object = educationCard;
                    break;
                case "Impots":
                    Card1Object = impotsCard;
                    break;
                case "JoiesDeLaRue":
                    Card1Object = joiesDeLaRueCard;
                    break;
                case "NouvelleTaxe":
                    Card1Object = nouvelleTaxeCard;
                    break;
                default:
                    Debug.Log("error with card name");
                    break;
            }

            switch (card2)
            {
                case "Convoi":
                    Card2Object = convoiCard;
                    break;
                case "Education":
                    Card2Object = educationCard;
                    break;
                case "Impots":
                    Card2Object = impotsCard;
                    break;
                case "JoiesDeLaRue":
                    Card2Object = joiesDeLaRueCard;
                    break;
                case "NouvelleTaxe":
                    Card2Object = nouvelleTaxeCard;
                    break;
                default:
                    Debug.Log("error with card name");
                    break;
            }

            //--------- Repositionner Les Cartes -------------------------
            
            if(Card1Object.transform.position.x != -3)
            {
                Card1Object.transform.position = new Vector3(-3, 0, 0);
            }
            
            Card1Object.SetActive(true);

            if(Card2Object.transform.position.x != 3)
            {
                Card2Object.transform.position = new Vector3(3, 0, 0);
            }
            Card2Object.SetActive(true);

            // ------------------------------------------------------------
        }

        public static void checkIfGameIsOver()
        {
            CardManager.CheckValues();
            Debug.Log("Food : " + CardManager.foodValue);
            Debug.Log("Army : " + CardManager.armyValue);
            Debug.Log("Gold : " + CardManager.goldValue);
            Debug.Log("Bonheur : " + CardManager.bonheurValue);
            Debug.Log("Evolution : " + CardManager.evolutionValue);

            if (CardManager.foodValue <= 0)
            {
                gameOverScreen.SetActive(true);
                gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
                gameOverText.text = "Votre peuple est mort de faim. \n Votre règne s'achève après " + turnCounterValue + " ans de règne.";
                gameIsOver = true;
            }
            if (CardManager.goldValue <= 0)
            {
                gameOverScreen.SetActive(true);
                gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
                gameOverText.text = "Votre Royaume est ruiné. \n Votre règne s'achève après " + turnCounterValue + " ans de règne.";
                gameIsOver = true;
            }
            if (CardManager.goldValue <= 0)
            {
                gameOverScreen.SetActive(true);
                gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
                gameOverText.text = "Votre Royaume est ruiné. \n Votre règne s'achève après " + turnCounterValue + " ans de règne.";
                gameIsOver = true;
            }
            if (CardManager.bonheurValue <= 0)
            {
                gameOverScreen.SetActive(true);
                gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
                gameOverText.text = "Votre peuple vous a destitué. \n Votre règne s'achève après " + turnCounterValue + " ans de règne.";
                gameIsOver = true;
            }

        }

        /*
            public static void createDeck()
            {
                Debug.Log("création du deck");
                GameObject Deck = new GameObject(); //Création d'un nouveau Deck
                Deck.name = "Deck";
                deck = GameObject.Find("Deck");


                //---------- Méthode avec otherTurnsCards[] ----------------------------

                GameObject instantiateCard1 = otherTurnsCards[card1Index];
                GameObject instance1 = Instantiate(instantiateCard1, new Vector3(-3, 0, 0f), Quaternion.identity) as GameObject;
                instance1.transform.parent = deck.transform;
                Debug.Log(otherTurnsCards[card1Index].name);

                GameObject instantiateCard2 = otherTurnsCards[card2Index];
                GameObject secondInstance = Instantiate(instantiateCard2, new Vector3(3, 0, 0f), Quaternion.identity) as GameObject;
                secondInstance.transform.parent = deck.transform;
                Debug.Log(otherTurnsCards[card2Index].name);

                Debug.Log("deck créé");

                //------------------------------------------------------------------------

            }
        */


    }
}