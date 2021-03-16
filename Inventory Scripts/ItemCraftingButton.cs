using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCraftingButton : MonoBehaviour
{
    public int CraftingIndex; // this index will store which id the button has, then you can toggle them via script by checking a bool array
    public Item itemToCraft;
    public Image itemToCraftIcon;
    public int IngredientAmount; //How many ingredients are needed to craft
    public Item FirstCraftingIngredient;
    public Item SecondCraftingIngredient;
    public Item ThirdCraftingIngredient;
    public Image FirstCraftingIngredientIcon;
    public Image SecondCraftingIngredientIcon;
    public Image ThirdCraftingIngredientIcon;
    public Text FirstCraftingAmountText;
    public Text SecondCraftingAmountText;
    public Text ThirdCraftingAmountText;
    public int FirstCraftingAmount;
    public int SecondCraftingAmount;
    public int ThirdCraftingAmount;
    public static Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        itemToCraftIcon.sprite = itemToCraft.icon;
        if (ThirdCraftingIngredient == null)
        {
            ThirdCraftingIngredientIcon.enabled = false;
            ThirdCraftingAmountText.enabled = false;
        }
        else
        {
            ThirdCraftingAmountText.text = "" + ThirdCraftingAmount;
            ThirdCraftingIngredientIcon.sprite = ThirdCraftingIngredient.icon;
        }
        if (SecondCraftingIngredient == null)
        {
            SecondCraftingIngredientIcon.enabled = false;
            SecondCraftingAmountText.enabled = false;
        }
        else
        {
            SecondCraftingAmountText.text = "" + SecondCraftingAmount;
            SecondCraftingIngredientIcon.sprite = SecondCraftingIngredient.icon;
        }
        FirstCraftingAmountText.text = "" + FirstCraftingAmount;
        FirstCraftingIngredientIcon.sprite = FirstCraftingIngredient.icon;
        
}
        
    public void CraftingButton()
    {

    }
    public bool IngredientCheck()
    {
        bool hasFirstItem = false;
        bool hasSecondItem = false;
        bool hasThirdItem = false;
        switch (IngredientAmount)
        {
            case 1:
                for (int i = 0; i < inventory.items.Count; i++)
                {
                    Item invItem = inventory.items[i];
                    if (FirstCraftingIngredient.name == invItem.name)
                    {
                        if (FirstCraftingAmount > 1)
                        {
                            if (FirstCraftingAmount <= invItem.itemAmount)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            
                            return true;
                        }
                    }
                }
                return false;
                    
            case 2:
                
                for (int i = 0; i < inventory.items.Count; i++)
                {
                    Item invItem = inventory.items[i];
                    if (FirstCraftingIngredient.name == invItem.name)
                    {
                        if (FirstCraftingAmount > 1)
                        {
                            if (FirstCraftingAmount <= invItem.itemAmount)
                            {
                                hasFirstItem = true;
                            }
                            else
                            {
                                hasFirstItem = false;
                            }
                        }
                        else
                        {

                            hasFirstItem = true;
                        }
                    }
                    else if (SecondCraftingIngredient.name == invItem.name)
                    {
                        if (SecondCraftingAmount > 1)
                        {
                            if (SecondCraftingAmount <= invItem.itemAmount)
                            {
                                hasSecondItem = true;
                            }
                            else
                            {
                                hasSecondItem = false;
                            }
                        }
                        else
                        {

                            hasSecondItem = true;
                        }
                    }

                }
                if (hasFirstItem == true && hasSecondItem == true)
                {
                    return true;
                }
                return false;
            case 3:
                for (int i = 0; i < inventory.items.Count; i++)
                {
                    Item invItem = inventory.items[i];
                    if (FirstCraftingIngredient.name == invItem.name)
                    {
                        if (FirstCraftingAmount > 1)
                        {
                            if (FirstCraftingAmount <= invItem.itemAmount)
                            {
                                hasFirstItem = true;
                            }
                            else
                            {
                                hasFirstItem = false;
                            }
                        }
                        else
                        {

                            hasFirstItem = true;
                        }
                    }
                    else if (SecondCraftingIngredient.name == invItem.name)
                    {
                        if (SecondCraftingAmount > 1)
                        {
                            if (SecondCraftingAmount <= invItem.itemAmount)
                            {
                                hasSecondItem = true;
                            }
                            else
                            {
                                hasSecondItem = false;
                            }
                        }
                        else
                        {

                            hasSecondItem = true;
                        }
                    }
                    else if (ThirdCraftingIngredient.name == invItem.name)
                    {
                        if (ThirdCraftingAmount > 1)
                        {
                            if (ThirdCraftingAmount <= invItem.itemAmount)
                            {
                                hasThirdItem = true;
                            }
                            else
                            {
                                hasThirdItem = false;
                            }
                        }
                        else
                        {

                            hasThirdItem = true;
                        }
                    }

                }
                if (hasFirstItem == true && hasSecondItem == true && hasThirdItem == true)
                {
                    return true;
                }
                return false;

            default:
                return false;
        }
    }
   public void CraftItem()
    {
        if (IngredientCheck())
        {
            switch (IngredientAmount)
            {
                case 1:
                    for (int i = 0; i < inventory.items.Count; i++)
                    {
                        Item invItem = inventory.items[i];
                        if (FirstCraftingIngredient.name == invItem.name)
                        {
                            if (FirstCraftingAmount > 1)
                            {
                                if (FirstCraftingAmount < invItem.itemAmount)
                                {
                                    invItem.itemAmount -= FirstCraftingAmount;
                                    break;
                                }
                                else
                                {
                                    inventory.Remove(invItem, true);
                                    break;
                                }
                            }
                            else
                            {
                                inventory.Remove(invItem, true);
                                break;
                            }
                        }
                    }
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    Debug.LogError("Crafting Item Deduction Switch Failed");
                    break;
            }
            inventory.Add(itemToCraft);
        }
    }
}
