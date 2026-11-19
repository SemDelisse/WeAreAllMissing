using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "ScriptableObjects/InventoryItem", order = 1)]
public class InventoryItem : ScriptableObject
{
    public string _ItemName;
    [TextArea(3, 10)]
    public string _ItemDescription;
    public Sprite _ItemSprite;
}
