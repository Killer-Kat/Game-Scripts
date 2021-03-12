using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseBuilding : MonoBehaviour
{
    public GameObject BuildingGUI;
    public GameObject MainRoomUnlocker, CraftingRoomUnlocker, KitchenUnlocker, backRoomUnlocker;
    public persistenceController pCon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnLevelWasLoaded(int level)
    {
        pCon = FindObjectOfType<persistenceController>();
        if(pCon.isMainRoomUnlocked == true)
        {
            MainRoomUnlocker.SetActive(true);
        }
        if (pCon.isCraftingRoomUnlocked == true)
        {
           CraftingRoomUnlocker.SetActive(true);
        }
        if (pCon.isKitchenUnlocked == true)
        {
            KitchenUnlocker.SetActive(true);
        }
        if (pCon.isBackRoomUnlocked == true)
        {
            backRoomUnlocker.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;


        if (collisionGameObject.name == "Player" && Input.GetButtonDown("Interact"))
        {
            ToggleUI();
        }

    }
    public void ToggleUI()
    {
        BuildingGUI.SetActive(!BuildingGUI.activeSelf);
    }
}
