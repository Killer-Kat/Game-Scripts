using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingGUI : MonoBehaviour
{
    //These bools are the different types of crafting, each workbench can either craft that kind or not.
    
    public GameObject craftingGUI;
    public GameObject WoodChoppingRecipes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    public void ToggleUI(bool WoodChopping)
    {
        craftingGUI.SetActive(!craftingGUI.activeSelf);
        if(WoodChopping == true)
        {
            WoodChoppingRecipes.SetActive(true);
        }
        else
        {
            WoodChoppingRecipes.SetActive(false);
        }
    }
     public void CloseGUI()
    {
        craftingGUI.SetActive(false);
    }

}
