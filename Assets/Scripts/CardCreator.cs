using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCreator : MonoBehaviour
{
   public List<Cards> TurnOneCards = new List<Cards>();
   public List<Cards> OtherTurnsCards = new List<Cards>();
   public static int ListLength;

   private void Start()
   {
      ListLength = OtherTurnsCards.Count;
   }
}
