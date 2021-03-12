using UnityEngine;
using UnityEngine.UI;

public class EquipmentUISlot : MonoBehaviour
{
   [SerializeField] private Image UIicon;
   [SerializeField] private Image TypeIcon;
    public Button removeButton;
    public Text itemAmountText;
    private EquipmentManager equipMan;
    Item UIitem; //making an Item class object called item, yes I am going to keep writing it down so I dont forget.

    public void AddItem(Item newItem)
    {
        UIitem = newItem; //Sets the item object at the start to the item object passed to this method

        UIicon.sprite = UIitem.icon;
        UIicon.enabled = true;
        TypeIcon.enabled = false;
        if (UIitem.isStackable == true)
        {
            itemAmountText.enabled = true;
            itemAmountText.text = "" + UIitem.itemAmount;
        }
        else
        {
            itemAmountText.enabled = false;
            itemAmountText.text = "0";
        }
        //Debug.Log("Slot SET! " + gameObject.name);
    }
    public void ClearUISlot()
    {


        UIicon.sprite = null;
        UIicon.enabled = false;
        TypeIcon.enabled = true;
        if (itemAmountText.enabled == true)
        {
            itemAmountText.enabled = false;
            itemAmountText.text = "0";
        }
        
        UIitem = null;
        //Debug.Log("Slot Cleared " + gameObject.name);
    }
    private void UseItem()
    {
        if (UIitem != null) //check if there is an item in the slot
        {
            equipMan = EquipmentManager.instance;
            for (int i = 0; i < equipMan.currentEquipment.Length; i++)
            {
                if (equipMan.currentEquipment[i] == null)
                {
                    //???
                }
                else if (UIitem.name == equipMan.currentEquipment[i].name)
                {
                    equipMan.Unequip(i);
                    break;
                }
            }
            
        }
    }
}
