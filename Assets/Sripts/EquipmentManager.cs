using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(Equipment.EquipmentSlot)).Length;   // get the amount of elements in an enum
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip (Equipment newItem)
    {
        int slotIndex = (int)newItem.equipmentSlot;  // (int) will take the number (index) of the correspandant equipment inside the enum

        Equipment oldItem = null;
        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.AddItem(oldItem);
        }

        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;
        
    }

    public void Unequip (int slotIndex)
    {
        if (currentEquipment[slotIndex] != null )
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.AddItem(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
        
    }

    public void UnequipALll ()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipALll();
        }
    }


}
