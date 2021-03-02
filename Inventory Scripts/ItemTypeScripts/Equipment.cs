using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName ="Inventory/Equipment")]
public class Equipment : Item
{
    
    public EquipmentSlot equipSlot;
    public int armorModifier;
    public int damageModifer;
    public float speedModifer;
    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this); //Grabs our equipment manager and passes it the item that called the Use() function
        RemoveFromInventory();
    }
}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Feet }

