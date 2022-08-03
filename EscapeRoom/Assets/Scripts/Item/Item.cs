using System;
using UnityEngine;

[Serializable]
public class Item
{

    //—ñ‹“Œ^Fí—Ş‚ğ—ñ‹“‚·‚é
    public enum Type
    {
        Cube,
        Ball,
        ClockHand,
        PlanetModel1,
        PlanetModel2,
        PlanetModel3,
        PlanetModel4,
        PlanetModel5,
        Screwdriver,
        BreakerButton,
        NauticalMap,
        KeyParts1,
        KeyParts2,

    }

    public Type type;     // í—Ş
    public Sprite sprite; // Slot‚É•\¦‚·‚é‰æ‘œ
    public GameObject zoomObj;

    public Item(Type type, Sprite sprite, GameObject zoomObj)
    {
        this.type = type;
        this.sprite = sprite;
   }
}