using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseBuildingButton : MonoBehaviour
{
    public persistenceController pCon;
    public GameObject RoomUnlocker; //Every room is saved as a seprate tilemap, that can be enabled or disabled.
    public Sprite RoomCompletedIcon; //Toggles Icon in GUI to show room building was sucessfull
    public Image RoomIcon;
    public Item[] CraftingIngredients; //Which items are needed to craft the room
    public int[] ItemAmountNeededToCraft; //how many of each item
    public int[] HasItemsCheck;
    public int roomToUnlockIndex; //Which Room this button unlocks
    Inventory inventory; //making an Inventory object called inventory
    // Start is called before the first frame update
    void Start()
    {
        pCon = FindObjectOfType<persistenceController>();
        inventory = Inventory.instance; //setting our inventory object to the singleton
        HasItemsCheck = new int [CraftingIngredients.Length];
        switch (roomToUnlockIndex)
        {
            case 0:
                if (pCon.isMainRoomUnlocked == true) { gameObject.SetActive(false); }
                break;
            case 1:
                if (pCon.isCraftingRoomUnlocked == true) { gameObject.SetActive(false); }
                break;
            case 2:
                if (pCon.isKitchenUnlocked == true) { gameObject.SetActive(false); }
                break;
            case 3:
                if (pCon.isBackRoomUnlocked == true) { gameObject.SetActive(false); }
                break;
            default:
                Debug.LogError("Invalid Room Index");
                break;

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IngredientCheck()
    {

        int var = 0;
        for (int i = 0; i < CraftingIngredients.Length; i++)
        {
            foreach (Item invItem in inventory.items)
            {
                if(CraftingIngredients[i].name == invItem.name)
                {
                    Debug.Log("Item found " + invItem.name);
                    if (ItemAmountNeededToCraft[i] > 1)
                    {
                        Debug.Log("amount needed to craft > 1 of " + invItem.name);
                        Debug.Log("Item amount " + invItem.itemAmount);
                        Debug.Log("item amount needed " + ItemAmountNeededToCraft[i]);
                        if(invItem.itemAmount >= ItemAmountNeededToCraft[i])
                        {
                            Debug.Log("Item need to craft >= amount of " + invItem.name);
                            HasItemsCheck[i] = 1;
                        }
                    }
                    else
                    {
                        Debug.Log("single item needed " + invItem.name);
                        HasItemsCheck[i] = 1;
                    }
                }
            }

        }

        for (int c = 0; c < HasItemsCheck.Length; c++) //and here I thought unity didnt support C++
        {
            var += HasItemsCheck[c]; //So the way this works is in the for loop if the required conditions are met it sets the array element to 1 then it adds the array and if the total value is equal to the length of the array we know it passed all the checks in each iteration
        }
        if (HasItemsCheck.Length == var)
        {
            return true;
        }
        else return false;
    }
    public void BuildRoom()
    {
        switch (roomToUnlockIndex)
        {
            case 0:
                if(pCon.isMainRoomUnlocked == true) { return; }
                break;
            case 1:
                if(pCon.isCraftingRoomUnlocked == true) { return; }
                break;
            case 2:
                if (pCon.isKitchenUnlocked == true) { return; }
                break;
            case 3:
                if(pCon.isBackRoomUnlocked == true){ return; }
                break;
            default:
                Debug.LogError("Invalid Room Index");
                break;

        }
        if (IngredientCheck())
        {
            for (int i = 0; i < CraftingIngredients.Length; i++)
            {
                for(int c = 0; c < inventory.items.Count; c++)
                {
                    Item invItem = inventory.items[c];
                    if (CraftingIngredients[i].name == invItem.name)
                    {
                        if (ItemAmountNeededToCraft[i] > 1)
                        {
                            if (ItemAmountNeededToCraft[i] < invItem.itemAmount)
                            {
                                invItem.itemAmount -= ItemAmountNeededToCraft[i];
                            }
                            else
                            {
                                invItem.itemAmount = 1;
                                inventory.Remove(invItem);
                            }
                        }
                        else
                        {
                            invItem.itemAmount = 1;
                            inventory.Remove(invItem);
                        }
                    }
                }

            }
            RoomUnlocker.SetActive(true);
            RoomIcon.sprite = RoomCompletedIcon;
            FindObjectOfType<InventoryUI>().UpdateUI();
            switch (roomToUnlockIndex)
            {
                case 0:
                    pCon.isMainRoomUnlocked = true;
                    break;
                case 1:
                    pCon.isCraftingRoomUnlocked = true;
                    break;
                case 2:
                    pCon.isKitchenUnlocked = true;
                    break;
                case 3:
                    pCon.isBackRoomUnlocked = true;
                    //Every variable you pass to me puts me one step closer to the edge and I'm about to  
                    break;
                default:
                    Debug.LogError("Invalid Room Index");
                    break;

            }
        }
        
    }
}
