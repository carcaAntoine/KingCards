using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public CardCreator cardCreator;
    public GameObject[] cardSlots;
    private void Start()
    {
        DisplayCards();
    }   

    private void DisplayCards()
    {
        for (int i = 0; i < cardCreator.TurnOneCards.Count; i++)
        {
           //Assigne infos des cards de cardCreator

           cardSlots[i].transform.GetChild(1).GetComponent<Image>().sprite = cardCreator.TurnOneCards[i].signetSprite;
           cardSlots[i].transform.GetChild(2).GetComponent<Text>().text = cardCreator.TurnOneCards[i].cardTitle;
           cardSlots[i].transform.GetChild(3).GetComponent<Text>().text = cardCreator.TurnOneCards[i].cardDescription;
           cardSlots[i].transform.GetChild(4).GetComponent<Image>().sprite = cardCreator.TurnOneCards[i].effect1Sprite;
           cardSlots[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = cardCreator.TurnOneCards[i].effect1Text;
           cardSlots[i].transform.GetChild(5).GetComponent<Image>().sprite = cardCreator.TurnOneCards[i].effect2Sprite;
           cardSlots[i].transform.GetChild(5).transform.GetChild(0).GetComponent<Text>().text = cardCreator.TurnOneCards[i].effect2Text;
        }
    }
}
