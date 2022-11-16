using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGame
{
    public class GameManager : MonoBehaviour
    {


        public GameObject[] turn1Cards;

        void TurnOne()
        {
            int x = -5;
            for (int i = 0; i < turn1Cards.Length; i++)
            {
                GameObject toInstantiate = turn1Cards[i];
                GameObject instance = Instantiate(toInstantiate, new Vector3(x, 0, 0f), Quaternion.identity) as GameObject;
                x = x + 5;
            }
        }

        void Start()
        {
            TurnOne();
        }


        void Update()
        {

        }
    }
}