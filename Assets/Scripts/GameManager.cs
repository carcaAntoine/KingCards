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
        static public GameObject[] otherTurnsCards;
        static public int turnCounterValue;
        static private Text turnCounterText;
        static private GameObject deck;
        static int card1Index = 0;
        static int card2Index = 0;

        void TurnOne()
        {
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
            Destroy (GameObject.Find("Deck"), .5f);
        }

        void Start()
        {
            deck = GameObject.Find("Deck");
            TurnOne();
        }

        public static void newTurn()
        {
            System.Random rdn = new System.Random();
            card1Index = rdn.Next(0, 4);
            card2Index = rdn.Next(0, 4);
            while(card1Index == card2Index)
            {
                card2Index = rdn.Next(0, 4);
            }
            Debug.Log(card1Index);
            Debug.Log(card2Index);
        }

    }
}