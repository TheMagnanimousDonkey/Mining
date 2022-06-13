using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName ="newtileclass",menuName ="Tile Class")]
public class TileClass : ScriptableObject
{
    public string tileName;
    public Sprite tileSprite;
    public bool isSolid = true;
    public bool isStackable = true;

    public float rarity;
}
