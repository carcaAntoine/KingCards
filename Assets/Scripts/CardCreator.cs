using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class CardCreator : MonoBehaviour
    {
        public List<Card> TurnOneCards = new List<Card>();
        public List<Card> OtherTurnsCards = new List<Card>();
        public static int ListLength;

        private void Start()
        {
            ListLength = OtherTurnsCards.Count;
        }
    }
}