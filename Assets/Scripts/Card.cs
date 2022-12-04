using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGame
{
    [System.Serializable]
    public class Card
    {
        public string cardTitle;
        [TextArea(1, 3)]
        public string cardDescription;
        public Sprite signetSprite;
        public Sprite effect1Sprite;
        public string effect1Text;
        public Sprite effect2Sprite;
        public string effect2Text;
        public int food;
        public int foodIncome;
        public int army;
        public int gold;
        public int goldIncome;
        public int happiness;
        public int people;
        public int cooldown;

    }
}