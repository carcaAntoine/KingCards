using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cards 
{
    public string cardTitle;
    [TextArea(1,3)]
    public string cardDescription;
    public Sprite signetSprite;
    public Sprite effect1Sprite;
    public string effect1Text;
    public Sprite effect2Sprite;
    public string effect2Text;
}
