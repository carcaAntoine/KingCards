using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace MyGame
{
public class CardManager : MouseOver
{
    static private Text foodText;
    static private int foodValue;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    static public void DisableCard()
    {
        foodText = GameObject.Find("FoodValue").GetComponent<Text>();
        foodValue = Convert.ToInt32(foodText.text);
        //Destroy(LoiAgricoleCard, 1);
        foodText.text = (foodValue + 5).ToString();
    }
}
}