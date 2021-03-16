using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingWorkBench : MonoBehaviour
{
    // Start is called before the first frame update
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
