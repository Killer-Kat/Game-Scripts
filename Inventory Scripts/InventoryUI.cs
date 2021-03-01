
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    Inventory inventory; //making an Inventory object called inventory
    public GameObject inventoryUI; //this variable stores the UI object in the editor

    InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance; //setting our inventory object to the singleton
        inventory.OnItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); //Get the inventory slots from our holder object
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
    void UpdateUI()
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
