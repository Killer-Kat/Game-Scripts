using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item; //This is an item class object that we are going to be picking up

    public void Pickup()
    {

        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item); //Because there is only ever one innventory object we can call the instance to get the inventory.
        if (wasPickedUp)
        {
            Destroy(gameObject); //Destroys whatever this script is on
        }
    }
}
