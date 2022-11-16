using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class MouseOver : MonoBehaviour
    {
        void OnMouseEnter()
        {
            Debug.Log("Mouse is over GameObject.");
        }

        void OnMouseExit()
        {
            Debug.Log("Mouse is no longer on GameObject.");
        }

        private void OnMouseDown()
        {
            Debug.Log("Mouse Click Detected");
            LoiAgricoleDisable.LoiAgricoleCard();
        }
    }

}