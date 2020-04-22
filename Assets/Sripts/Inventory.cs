using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one item found !!");
        }
        instance = this;
    }
    #endregion

    public List<Item> items = new List<Item>();
    public int inventorySlots = 20;
    public bool AddItem (Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= inventorySlots )
            {
                Debug.Log("Not enough place");
                return false;
            }
            items.Add(item);
        }
        return true;
    }

    public void RemoveItem (Item item)
    {
        items.Remove(item);
    }
}
