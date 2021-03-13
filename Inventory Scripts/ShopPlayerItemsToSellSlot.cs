using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ShopPlayerItemsToSellSlot : MonoBehaviour
{
    public ShopManager shopMan;
    public Image icon;
    public Text itemNameText;
    public Button sellButton;
    public Image sellButtonImage;
    public Text itemAmountText;
    public Text valueText;
    Item item; //making an Item class object called item, yes I am going to keep writing it down so I dont forget.
    PlayerStats pStats;

    public void Start()
    {
        pStats = FindObjectOfType<PlayerStats>();
        shopMan = FindObjectOfType<ShopManager>();
    }
    public void AddItem(Item newItem)
    {
        item = newItem; //Sets the item object at the start to the item object passed to this method

        icon.sprite = item.icon;
        icon.enabled = true;
        sellButtonImage.enabled = true;
        sellButton.enabled = true;
        valueText.enabled = true;
        valueText.text = "" + item.itemValue;
        itemNameText.text = item.name;
        if (item.isStackable == true)
        {
            itemAmountText.enabled = true;
            itemAmountText.text = "" + item.itemAmount;
        }
        else
        {
            itemAmountText.enabled = false;
            itemAmountText.text = "0";
        }
        
    }
    public void ClearSlot()
    {
        
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        sellButtonImage.enabled = false;
        sellButton.enabled = false;
        valueText.enabled = false;
        itemNameText.text = "";
        if (itemAmountText.enabled == true)
        {
            itemAmountText.enabled = false;
            itemAmountText.text = "0";
        }
        
    }
    public void SellItem() {
        if(item != null)
        {

            FindObjectOfType<AudioManager>().Play("Coin");
            pStats.currentMoney = pStats.currentMoney + item.itemValue;
            if (item.isStackable == false | (item.itemAmount == 1 && item.isStackable == true))
            {
                Inventory.instance.Remove(item, true);
            }
            if(item.isStackable == true && item.itemAmount > 1)
            {
                item.itemAmount -= 1;
            }
            FindObjectOfType<UIManager>().coinGUIupdate();
            shopMan.UpdateUI();
        }
         }
}
