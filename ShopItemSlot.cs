using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemSlot : MonoBehaviour
{
    public GameObject prefabToSell;
    public Image icon;
    public Text SalePriceText;
    public int salePrice;
    public Transform PlaceItemHereAfterBought;
    public PlayerStats pStats;

    void Start()
    {
        SalePriceText.text = "" + salePrice;
        pStats = FindObjectOfType<PlayerStats>();
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
            Instantiate(prefabToSell, PlaceItemHereAfterBought.position, PlaceItemHereAfterBought.rotation);
            //Play sound
            pStats.UIMan.coinGUIupdate();
        }
    }
}
