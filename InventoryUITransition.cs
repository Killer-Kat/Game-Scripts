using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUITransition : MonoBehaviour
{
    private GameObject[] InventoryGUIs;
    // Start is called before the first frame update
    private void OnLevelWasLoaded(int level)
    {
        InventoryGUIs = GameObject.FindGameObjectsWithTag("Inventory Gui");

        if (InventoryGUIs.Length > 1)
        {
            Destroy(InventoryGUIs[1]);
        }
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
