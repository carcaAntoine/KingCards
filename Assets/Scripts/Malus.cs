using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    [System.Serializable]
    public class Malus
    {
        public string malusName;
        public string alertLevel;
        [TextArea(1, 3)]
        public string malusDescription;
        public Sprite malusSprite;
        public string malusEffectText;

    }
