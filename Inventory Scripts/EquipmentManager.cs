using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion
    //[SerializeField]
    public Equipment[] currentEquipment;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment olditem);
    public OnEquipmentChanged onEquipmentChanged;
    public EquipmentUI equipmentUI;

    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length; //Gets the length of our equipment slots enum 
        currentEquipment = new Equipment[numSlots];
        equipmentUI = FindObjectOfType<EquipmentUI>();

    }
    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot; //gets the index number of our enum, thus letting us know what type of item it is.

        Equipment oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }
        if(onEquipmentChanged != null) // Allows us to update when we change our equipment
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;
        equipmentUI.UpdateUI();



    }
    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null) // Allows us to update when we change our equipment
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
            equipmentUI.UpdateUI();
        }
    }
    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

   /* void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }*/
}
