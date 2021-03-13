using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item; //This is an item class object that we are going to be picking up
    public SpriteRenderer SR;
    public static GameObject[] ItemPickupPrefabSize;
    

    private void Start()
    {
        SR.sprite = item.icon;
    }
    public void Pickup()
    {

        
            bool wasPickedUp = Inventory.instance.AddItemFromPickup(item); //Because there is only ever one innventory object we can call the instance to get the inventory.
            if (wasPickedUp)
            {
                FindObjectOfType<AudioManager>().Play(item.pickUpSound);
                Destroy(gameObject); //Destroys whatever this script is on
            }
            else
            {
            FindObjectOfType<PlayerController>().DelayPickup();
                
            }
        
    }
    public void SetItem(Item itemToSet) 
    {
        item = itemToSet;
    }
    
}

    
