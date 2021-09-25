using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemSlot : MonoBehaviour
{
    public Item item2sell;
    public Image icon;
    public Text SalePriceText;
    public int salePrice;
    public Transform PlaceItemHereAfterBought;
    Inventory inventory;
    void Start()
    {
        SalePriceText.text = "" + salePrice;
        inventory = Inventory.instance; //setting our inventory object to the singleton //Future KillerKat here, not sure if there is a reason beyond being conveinent that brackeys saves the singleton into a new object. Just incase I'll leave it like this for now.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BuyItem()
    {
        if (PlayerStats.Instance.currentMoney >= salePrice)
        {
            PlayerStats.Instance.currentMoney = PlayerStats.Instance.currentMoney - salePrice;
            inventory.Add(item2sell);
            //Play sound
            PlayerStats.Instance.UIMan.coinGUIupdate();
        }
    }
}
