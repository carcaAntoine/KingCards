using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MalusCreator : MonoBehaviour
{
    public List<Malus> MalusList = new List<Malus>();
    public static int mlLength;

    private void Start()
    {
        mlLength = MalusList.Count;
    }

}
