using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCraftingButton : MonoBehaviour
{
   
    public Item itemToCraft;
    public int amountOfItemsCrafted = 1; //How many items are being crafted by this recipe 
    public Text AmountCraftedText;
    public Image itemToCraftIcon;
    public Text itemToCraftName;
    private int IngredientAmount; //How many ingredients are needed to craft

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
   
    void Start()
    {
        inventory = Inventory.instance;
        itemToCraftIcon.sprite = itemToCraft.icon;
        itemToCraftName.text = itemToCraft.name + ": " + itemToCraft.description;
        AmountCraftedText.text = "" + amountOfItemsCrafted;
        if (SecondCraftingIngredient == null)
        {
            IngredientAmount = 1;
        } else if(ThirdCraftingIngredient == null)
        {
            IngredientAmount = 2;
        }
        else
        {
            IngredientAmount = 3;
        }
        switch (IngredientAmount)//Here we just check if we need to set the GUI for the second and third crafting ingredients
        {
            case 1:
                SecondCraftingIngredientIcon.enabled = false;
                SecondCraftingAmountText.enabled = false;
                ThirdCraftingIngredientIcon.enabled = false;
                ThirdCraftingAmountText.enabled = false;
                break;
            case 2:
                SecondCraftingAmountText.text = "" + SecondCraftingAmount;
                SecondCraftingIngredientIcon.sprite = SecondCraftingIngredient.icon;
                ThirdCraftingIngredientIcon.enabled = false;
                ThirdCraftingAmountText.enabled = false;
                break;
            case 3:
                SecondCraftingAmountText.text = "" + SecondCraftingAmount;
                SecondCraftingIngredientIcon.sprite = SecondCraftingIngredient.icon;
                ThirdCraftingAmountText.text = "" + ThirdCraftingAmount;
                ThirdCraftingIngredientIcon.sprite = ThirdCraftingIngredient.icon;
                break;

            default:
                Debug.LogWarning("No Items Set In Crafting Button!");
                break;
                
        }

        FirstCraftingAmountText.text = "" + FirstCraftingAmount;
        FirstCraftingIngredientIcon.sprite = FirstCraftingIngredient.icon;
        
    }
        
    public void CraftingButton()
    {

    }
    public bool IngredientCheck() //Returns true if we have enough to craft the item, otherwise returns false.
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
         bool RemoveFirstIngredient()
        {
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
                            return true;
                        }
                        else
                        {
                            inventory.Remove(invItem, true);
                            return true;
                        }
                    }
                    else
                    {
                        inventory.Remove(invItem, true);
                        return true;
                    }
                }
            }
            return false;
        }
        bool RemoveSecondIngredient()
        {
            for (int i = 0; i < inventory.items.Count; i++)
            {
                Item invItem = inventory.items[i];
                if (SecondCraftingIngredient.name == invItem.name)
                {
                    if (SecondCraftingAmount > 1)
                    {
                        if (SecondCraftingAmount < invItem.itemAmount)
                        {
                            invItem.itemAmount -= SecondCraftingAmount;
                            return true;
                        }
                        else
                        {
                            inventory.Remove(invItem, true);
                            return true;
                        }
                    }
                    else
                    {
                        inventory.Remove(invItem, true);
                        return true;
                    }
                }
            }
            return false;
        }
        bool RemoveThirdIngredient()
        {
            for (int i = 0; i < inventory.items.Count; i++)
            {
                Item invItem = inventory.items[i];
                if (ThirdCraftingIngredient.name == invItem.name)
                {
                    if (ThirdCraftingAmount > 1)
                    {
                        if (ThirdCraftingAmount < invItem.itemAmount)
                        {
                            invItem.itemAmount -= ThirdCraftingAmount;
                            return true;
                        }
                        else
                        {
                            inventory.Remove(invItem, true);
                            return true;
                        }
                    }
                    else
                    {
                        inventory.Remove(invItem, true);
                        return true;
                    }
                }
            }
            return false;
        }
        if (IngredientCheck())
        {
            switch (IngredientAmount)
            {
                case 1:
                    if (RemoveFirstIngredient())
                    {
                        break;
                    }
                    else 
                    {
                        Debug.LogError("Crafting Happened but did not remove " + FirstCraftingIngredient.name);
                            break;
                    }
                    
                case 2:
                    if (RemoveFirstIngredient() == false)
                    {
                        Debug.LogError("Crafting Happened but did not remove " + FirstCraftingIngredient.name);
                    }
                    if (RemoveSecondIngredient())
                    {
                        break;
                    }
                    else
                    {
                        Debug.LogError("Crafting Happened but did not remove " + SecondCraftingIngredient.name);
                        break;
                    }

                case 3:
                    if (RemoveFirstIngredient() == false)
                    {
                        Debug.LogError("Crafting Happened but did not remove " + FirstCraftingIngredient.name);
                    }
                    if (RemoveSecondIngredient() == false)
                    {
                        Debug.LogError("Crafting Happened but did not remove " + SecondCraftingIngredient.name);
                    }
                    if (RemoveThirdIngredient())
                    {
                        break;
                    }
                    else
                    {
                        Debug.LogError("Crafting Happened but did not remove " + ThirdCraftingIngredient.name);
                        break;
                    }
                default:
                    Debug.LogError("Crafting Item Deduction Switch Failed");
                    break;
            }
            for (int i = 0; i < amountOfItemsCrafted; i++)
            {
                inventory.Add(itemToCraft);
            }
            FindObjectOfType<AudioManager>().Play(itemToCraft.pickUpSound);
        }
    }
}
