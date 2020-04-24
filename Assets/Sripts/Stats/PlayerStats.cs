using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEquipmentChanged(Equipment newItem, Equipment olditem)
    {

    }
}
