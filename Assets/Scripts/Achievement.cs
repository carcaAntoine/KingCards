using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


namespace MyGame
{
    [System.Serializable]

    public class Achievement
    {
        public string trophyID;
        public string trophyTitle;

        [TextArea(1, 3)]
        public string trophyDescription;
        public Sprite trophySprite;
        public Sprite ifLocked;
    }
}