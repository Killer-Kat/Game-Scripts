using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingWorkBench : MonoBehaviour
{
    //These bools are the different types of crafting, each workbench can either craft that type of item or not.
    public bool WoodChopping;
    CraftingGUI craftingGUI;
    void Start()
    {
        craftingGUI = FindObjectOfType<CraftingGUI>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;


        if (collisionGameObject.name == "Player" && Input.GetButtonDown("Interact"))
        {
            craftingGUI.ToggleUI(WoodChopping);
        }

    }
}
