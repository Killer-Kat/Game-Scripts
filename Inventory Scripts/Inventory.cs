using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

   
    public static Inventory instance;
    
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found! "); //Because this static varible calls back to this class we can only ever have one object with this script on it in our game.
                return;
        }
        instance = this;
    }
    #endregion

    public int space = 20; //The amount of space in the inventory
    public GameObject PickupPrefab;
    public delegate void OnItemChanged(); //The delegate is an event that you can attach some methods to, then when the event is trigged all the methods are called.
    public OnItemChanged OnItemChangedCallback;
    private Transform PlayerTransform;
    public List<Item> items = new List<Item>(); //Making a new list of Item classes called "items"

    public bool Add (Item item) //Adds an Item class object to the list "items"
    {
        if(item.isStackable == true)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if(items[i].name == item.name)
                {
                    items[i].itemAmount++;
                    //Debug.Log("Player now has " + items[i].itemAmount + " " + items[i].name);
                    if (OnItemChangedCallback != null) //can remove later, just making sure we have methods attached so we dont get an error.
                    {
                        OnItemChangedCallback.Invoke(); // let everyone know we picked up an item.
                    }
                    return true;
                }
            }
        }
                
        if (items.Count >= space) //see if we have enough space to pick the item up
        {
            Debug.Log("Not Enough Room to pickup " + item.name);
            DropItem(item, false);
            return false;
        }
        items.Add(item);
        if (OnItemChangedCallback != null) //can remove later, just making sure we have methods attached so we dont get an error.
        {
            OnItemChangedCallback.Invoke(); // let everyone know we picked up an item.
        }
        return true;
    }
    public bool AddItemFromPickup(Item item) //This function should be called by items in the world, instead of dropping the item into the world it just wont delete the one thats already there.
    {
        if (item.isStackable == true)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].name == item.name)
                {
                    items[i].itemAmount++;
                    //Debug.Log("Player now has " + items[i].itemAmount + " " + items[i].name);
                    if (OnItemChangedCallback != null) //can remove later, just making sure we have methods attached so we dont get an error.
                    {
                        OnItemChangedCallback.Invoke(); // let everyone know we picked up an item.
                    }
                    return true;
                }
            }
        }

        if (items.Count >= space) //see if we have enough space to pick the item up
        {
            Debug.Log("Not Enough Room to pickup " + item.name);
            return false;
        }
        items.Add(item);
        if (OnItemChangedCallback != null) //can remove later, just making sure we have methods attached so we dont get an error.
        {
            OnItemChangedCallback.Invoke(); // let everyone know we picked up an item.
        }
        return true;
    }
    public void Remove (Item item, bool ResetStack) //Removes an Item class object from the list "items"
    {
        if (ResetStack) { item.itemAmount = 1; } //not zero but  one because pickup doesnt increase amount on the first item
        items.Remove(item);
        if (OnItemChangedCallback != null) //can remove later, just making sure we have methods attached so we dont get an error.
        {
            OnItemChangedCallback.Invoke(); // let everyone know we picked up an item.
        }
    }
    public void DropItem(Item item, bool FromInventory)
    {
        FindObjectOfType<PlayerController>().DelayPickup();
        PlayerTransform = FindObjectOfType<PlayerController>().transform;
        var obj = Instantiate(PickupPrefab, PlayerTransform.position, PlayerTransform.rotation);
        obj.GetComponent<ItemPickup>().SetItem(item);
        obj.transform.localScale = item.itemPickupScale;
        if (FromInventory) { Remove(item, false);}
    }
}
