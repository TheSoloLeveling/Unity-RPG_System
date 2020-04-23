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

    private void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(Equipment.EquipmentSlot)).Length;   // get the amount of elements in an enum
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip (Equipment newItem)
    {
        int slotIndex = (int)newItem.equipmentSlot;  // (int) will take the number (index) of the correspandant equipment inside the enum
        currentEquipment[slotIndex] = newItem;     
    }

}
