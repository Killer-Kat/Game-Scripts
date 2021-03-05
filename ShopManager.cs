using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Transform PlayerItemsToSellHolder;
    public GameObject ShopUI;
    public ShopItemSlot[] ShopSlots;
    public InventoryUI inventoryUI;
    ShopPlayerItemsToSellSlot[] slots; //Stores the players inventory slots so we can display them in the sell window
    Inventory inventory; //making an Inventory object called inventory
    void Start()
    {
        inventoryUI = FindObjectOfType<InventoryUI>();
        inventory = Inventory.instance; //setting our inventory object to the singleton
        inventory.OnItemChangedCallback += inventoryUI.UpdateUI;
        slots = PlayerItemsToSellHolder.GetComponentsInChildren<ShopPlayerItemsToSellSlot>(); //Get the inventory slots from our holder object
        UpdateUI();


    }
    public void toggleUI()
    {
        ShopUI.SetActive(!ShopUI.activeSelf);
    }
    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]); //For every item slot get an item from our inventory
            }
            else
            {
                slots[i].ClearSlot(); //if there are no more inventory items, then set the slot to empty
            }
        }
    }
}
