
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

   new public string name = "New Item";
   public Sprite icon = null;
    public string pickUpSound = "Coin";
    public int itemAmount;
    public bool isStackable;
    public virtual void Use()
    {
        //PUt what you use the item for here
        Debug.Log("Using " + name);
    }
    public void RemoveFromInventory()
    {
        this.itemAmount = 1; //setting it to one and not zero becuase our current code doesnt increase the item count if its the first one you pick up
        Inventory.instance.Remove(this);
    }
}
