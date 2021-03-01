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

    public delegate void OnItemChanged(); //The delegate is an event that you can attach some methods to, then when the event is trigged all the methods are called.
    public OnItemChanged OnItemChangedCallback;

    public List<Item> items = new List<Item>(); //Making a new list of Item classes called "items"

    public bool Add (Item item) //Adds an Item class object to the list "items"
    {
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
    public void Remove (Item item) //Removes an Item class object from the list "items"
    {
        items.Remove(item);
        if (OnItemChangedCallback != null) //can remove later, just making sure we have methods attached so we dont get an error.
        {
            OnItemChangedCallback.Invoke(); // let everyone know we picked up an item.
        }
    }
}
