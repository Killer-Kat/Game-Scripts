
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    Item item; //making an Item class object called item, yes I am going to keep writing it down so I dont forget.

    public void AddItem (Item newItem)
    {
        item = newItem; //Sets the item object at the start to the item object passed to this method

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }
    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item); // pass the item in the item slot to the remove function of the inventory singleton
    }
    public void UseItem ()
    {
        if(item != null) //check if there is an item in the slot
        {
            item.Use();
        }
    }
}
