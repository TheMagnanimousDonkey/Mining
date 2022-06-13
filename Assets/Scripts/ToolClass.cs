using System.Collections;


using UnityEngine;

[CreateAssetMenu(fileName ="ToolClass",menuName ="Tool Class")]
public class ToolClass : ScriptableObject
{
    public string name;
    public Sprite spite;
    public ItemClass.ToolType toolType;
}
