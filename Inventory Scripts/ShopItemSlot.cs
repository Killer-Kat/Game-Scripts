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
    static public PlayerStats pStats;
    Inventory inventory;
    void Start()
    {
        SalePriceText.text = "" + salePrice;
        pStats = FindObjectOfType<PlayerStats>();
        inventory = Inventory.instance; //setting our inventory object to the singleton
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BuyItem()
    {
        if (pStats.currentMoney >= salePrice)
        {
            pStats.currentMoney = pStats.currentMoney - salePrice;
            inventory.Add(item2sell);
            //Play sound
            pStats.UIMan.coinGUIupdate();
        }
    }
}
