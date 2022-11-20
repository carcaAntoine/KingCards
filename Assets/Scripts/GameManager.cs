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
        static public int turnCounterValue;
        static private Text turnCounterText;
        static private GameObject deck;
        static int card1Index = 0;
        static int card2Index = 0;
        public static int numberOfCards = 4; //Nombre de cartes dans Other Turn Cards

        void TurnOne()
        {
            Debug.Log(otherTurnsCards.Length);
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
            Destroy(GameObject.Find("Deck"), .5f);
        }

        void Start()
        {
            Debug.Log("Le jeu démarre");
            deck = GameObject.Find("Deck");
            TurnOne();
            //newTurn();
        }

        public void newTurn()
        {
            //numberOfCards = otherTurnsCards.Length;
            Debug.Log("nombre de cartes : " + numberOfCards);
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

            GameObject Deck = new GameObject(); //Création d'un nouveau Deck
            Deck.name = "Deck";
            deck = GameObject.Find("Deck");
            createDeck();
            
        }

        void createDeck()
        {
            Debug.Log("création du deck");
            GameObject instantiateCard1 = otherTurnsCards[card1Index];
            GameObject instance = Instantiate(instantiateCard1, new Vector3(-5, 0, 0f), Quaternion.identity) as GameObject;
            instance.transform.parent = deck.transform;
            
            GameObject instantiateCard2 = otherTurnsCards[card2Index];
            GameObject secondInstance = Instantiate(instantiateCard2, new Vector3(5, 0, 0f), Quaternion.identity) as GameObject;
            secondInstance.transform.parent = deck.transform;
            
        }

    }
}