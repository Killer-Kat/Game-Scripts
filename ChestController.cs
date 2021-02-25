using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public int chestRefNumber; //This stores a value thats unique to each chest.
    private bool isOpen = false;
    public SpriteRenderer spriteRenderer;
    public Sprite OpenedChest;
    public GameObject objectInChest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if(isOpen == false)
        {
            if (collisionGameObject.name == "Player" && Input.GetButtonDown("Interact"))
            {
                OpenChest();
            }
        }
    }
    private void OpenChest()
    {
        isOpen = true;
        spriteRenderer.sprite = OpenedChest;
        Instantiate(objectInChest, transform.position, transform.rotation);
    }
}
