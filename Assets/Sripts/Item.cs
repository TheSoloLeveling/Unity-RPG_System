
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "New item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
}

