using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class MouseOver : MonoBehaviour
    {
        //private string functionName;
        //private GameObject selectionnedCard;
        /* void OnMouseEnter()
         {
             Debug.Log("Mouse is over GameObject.");
         }

         void OnMouseExit()
         {
             Debug.Log("Mouse is no longer on GameObject.");
         }
 */
        /*
                private void OnMouseDown()
                {
                    //selectionnedCard = 
                    functionName = selectionnedCard.name;
                    Debug.Log(functionName);
                    CardManager.LoiAgricoleCard();
                }
        */
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    if (hit.transform != null) //voit si l'élément existe
                    {
                        PrintName(hit.transform.gameObject);
                    }
                }
            }
        }

        private void PrintName(GameObject go)
        {
            Debug.Log(go.name);
        }

    }
}