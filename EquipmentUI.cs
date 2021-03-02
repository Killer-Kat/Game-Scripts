using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    public Transform equipmentSlotHolder;
    private EquipmentManager equipMan; //making a Equipment manager class  object and calling it equipman
    private Inventory inventory; //making an Inventory object called inventory
    EquipmentUISlot[] slots;
    private void Start()
    {
        slots = equipmentSlotHolder.GetComponentsInChildren<EquipmentUISlot>(); //Get the inventory slots from our holder object
        inventory = Inventory.instance; //setting our inventory object to the singleton
        equipMan = EquipmentManager.instance; //setting our inventory object to the singleton
        inventory.OnItemChangedCallback += UpdateUI;


    }
    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < equipMan.currentEquipment.Length)
            {
                if (equipMan.currentEquipment[i] != null)
                {
                    slots[i].AddItem(equipMan.currentEquipment[i]); //For every item slot get an item from our inventory
                }
                else
                {
                    slots[i].ClearUISlot();
                }
            }
            else
            {
                slots[i].ClearUISlot(); //if there are no more inventory items, then set the slot to empty
            }
        }


    }
    
}
