using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperNpcScript : MonoBehaviour
{
    public ShopManager shopManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        
        
            if (collisionGameObject.name == "Player" && Input.GetButtonDown("Interact"))
            {
            TalkToShopKeeper();
            }
        
    }
    public void TalkToShopKeeper()
    {
        //Need to add speech system.
        shopManager.toggleUI();
    }
}
