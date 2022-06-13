using System.Collections;
using UnityEngine;

public class ItemClass
{
    public enum ItemType
    {
        block,
        tool
    }

    public enum ToolType
    {
        pickaxe,
        hammer
    }

    public ItemType itemType;
    public ToolType toolType;

    public TileClass tile;
    public ToolClass tool;

    public string name;
    public Sprite sprite;
    public bool isStackable;

    public ItemClass (TileClass _tile)
    {
        name = _tile.name;
        sprite = _tile.tileSprite;
        isStackable = _tile.isStackable;
        itemType = ItemType.block;
    }

    public ItemClass(ToolClass _tool)
    {
        name = _tool.name;
        sprite = _tool.spite;
        isStackable = false;
        itemType = ItemType.tool;
        toolType = _tool.toolType;
    }


}
