using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingGUI : MonoBehaviour
{
    public GameObject craftingGUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleUI()
    {
        craftingGUI.SetActive(!craftingGUI.activeSelf);
    }
}
