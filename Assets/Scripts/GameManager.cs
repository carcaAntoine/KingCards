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
        static string[] cardsList = new string[] { "Convoi", "Education", "Impots", "JoiesDeLaRue" };
        static string card1; //Nom de la première carte, tiré du tableau cardList
        static string card2; //Nom de la deuxième carte, tiré du tableau cardList
        static public int turnCounterValue;
        static private Text turnCounterText;
        static private GameObject deck;
        static int card1Index = 0;
        static int card2Index = 0;
        public static int numberOfCards = 4; //Nombre de cartes dans Other Turn Cards
        static private GameObject Card1Object; //1re carte à afficher
        static private GameObject Card2Object; //2e carte à afficher


        void Start()
        {
            deck = GameObject.Find("Deck");

            // "Désactivation" des cartes non utilisées
            GameObject.Find("Convoi").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Convoi").GetComponent<BoxCollider2D>().enabled = false;
            GameObject.Find("Education").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Education").GetComponent<BoxCollider2D>().enabled = false;
            GameObject.Find("Impots").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Impots").GetComponent<BoxCollider2D>().enabled = false;
            GameObject.Find("JoiesDeLaRue").GetComponent<Renderer>().enabled = false;
            GameObject.Find("JoiesDeLaRue").GetComponent<BoxCollider2D>().enabled = false;
            //-----------------------------------------

            TurnOne();
        }

        void TurnOne()
        {
            Debug.Log("turn1Cards Length : " + turn1Cards.Length);
            Debug.Log("otherTurnCards Length : " + otherTurnsCards.Length);
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
            turnCounterValue += 1;
            turnCounterText.text = turnCounterValue.ToString();
            Debug.Log("EndTurn appelé");

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
                    Card1Object = GameObject.Find("Convoi");
                    break;
                case "Education":
                    Card1Object = GameObject.Find("Education");
                    break;
                case "Impots":
                    Card1Object = GameObject.Find("Impots");
                    break;
                case "JoiesDeLaRue":
                    Card1Object = GameObject.Find("JoiesDeLaRue");
                    break;
                default:
                    Debug.Log("error with card name");
                    break;
            }

            switch (card2)
            {
                case "Convoi":
                    Card2Object = GameObject.Find("Convoi");
                    break;
                case "Education":
                    Card2Object = GameObject.Find("Education");
                    break;
                case "Impots":
                    Card2Object = GameObject.Find("Impots");
                    break;
                case "JoiesDeLaRue":
                    Card2Object = GameObject.Find("JoiesDeLaRue");
                    break;
                default:
                    Debug.Log("error with card name");
                    break;
            }

            Card1Object.transform.Translate(-3, 0, 0f);
            Card1Object.GetComponent<Renderer>().enabled = true;
            Card1Object.GetComponent<BoxCollider2D>().enabled = true;

            Card2Object.transform.Translate(3, 0, 0f);
            Card2Object.GetComponent<Renderer>().enabled = true;
            Card2Object.GetComponent<BoxCollider2D>().enabled = true;
            // ------------------------------------------------------------
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