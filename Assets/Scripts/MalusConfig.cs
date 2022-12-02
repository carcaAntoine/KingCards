using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace MyGame
{
    public class MalusConfig : MonoBehaviour
    {
        public Malus malus;
        public Malus myMalus;

        public void ConfigureMalus(Malus malus)
        {
            //affichage du malus

            transform.GetChild(0).GetComponent<Text>().text = malus.alertLevel.ToString();
            transform.GetChild(1).GetComponent<Text>().text = malus.malusDescription;
            transform.GetChild(2).GetComponent<Image>().sprite = malus.malusSprite;
            transform.GetChild(2).GetChild(0).GetComponent<Text>().text = malus.malusEffectText;
            myMalus = malus;

            /*
            malusTitle.text = malusCreator.MalusList[malusIndex].alertLevel;
            malusDesc.text = malusCreator.MalusList[malusIndex].malusDescription;
            malusEffectIcon.sprite = malusCreator.MalusList[malusIndex].malusSprite;
            malusEffect.text = malusCreator.MalusList[malusIndex].malusEffectText;*/
        }

    }
}