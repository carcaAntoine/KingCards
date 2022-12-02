using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AlertLevel
{
    Alerte,
    Catastrophe
}

[System.Serializable]
public class Malus
{
    public string malusName;
    public AlertLevel alertLevel;
    [TextArea(1, 3)]
    public string malusDescription;
    public Sprite malusSprite;
    public string malusEffectText;
    public int foodMalus;
    public int armyMalus;
    public int goldMalus;
    public int happinessMalus;
    public int peopleMalus;

}
