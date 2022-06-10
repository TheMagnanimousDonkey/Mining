using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "TileAtlas", menuName = "Tile Atlas")]
public class TileAtlas : ScriptableObject
{
    public TileClass stone;
    public TileClass dirt;
    public TileClass iron;
}
