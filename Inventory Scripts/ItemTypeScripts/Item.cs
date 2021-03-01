
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
        Inventory.instance.Remove(this);
    }
}
