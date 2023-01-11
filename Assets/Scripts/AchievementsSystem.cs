using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


namespace MyGame
{
    public class AchievementsSystem : MonoBehaviour
    {
        public Achievements achievements;
        public List<Achievement> achievementsList = new List<Achievement>();
        public GameObject[] trophiesSlots;

        public void InitialiseTrophies()
        {
            for(int i = 0; i <achievementsList.Count; i++)
            {
                trophiesSlots[i].GetComponent<Achievements>().ConfigureTrophy(achievementsList[i]);
            }
            
        }

    }
}