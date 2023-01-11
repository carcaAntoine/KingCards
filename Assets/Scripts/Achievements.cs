using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace MyGame
{
    public class Achievements : MonoBehaviour
    {
        public Achievement achievement;

        public Sprite lockedTrophyIcon;

        public void ConfigureTrophy(Achievement achievement)
        {
            if(PlayerPrefs.HasKey(achievement.trophyID))
            {
                transform.GetChild(0).GetComponent<Image>().sprite = achievement.trophySprite;
                transform.GetComponent<Image>().color = new Color32(255,255,255,255);
            }else
            {
                transform.GetChild(0).GetComponent<Image>().sprite = achievement.ifLocked;
                transform.GetComponent<Image>().color = new Color32(193,193,193,255);
            }
            transform.GetChild(1).GetComponent<Text>().text = achievement.trophyTitle;
            transform.GetChild(2).GetComponent<Text>().text = achievement.trophyDescription;
        }
    }
}