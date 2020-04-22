using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    public void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool hasPickedUp = Inventory.instance.AddItem(item); 

        if (hasPickedUp)
        {
            Destroy(gameObject);
        }
        
    }
}
