﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public int chestRefNumber; //This stores a value thats unique to each chest.
    //[SerializeField] //Enable this if a you need to see if the flag is toggled in game.
    private bool isOpen = false;
    public Transform spawnPoint;
    public SpriteRenderer spriteRenderer;
    public Sprite OpenedChest;
    public GameObject objectInChest;
    private persistenceController persistenceCon;
    // Start is called before the first frame update
    void Start()
    {
        persistenceCon = FindObjectOfType<persistenceController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnLevelWasLoaded(int level)
    {
        if (FindObjectOfType<persistenceController>().chestStatus[chestRefNumber] == true)
        {
            isOpen = true;
            spriteRenderer.sprite = OpenedChest;
        }
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
        persistenceCon.chestStatus[chestRefNumber] = true;
        spriteRenderer.sprite = OpenedChest;
        Instantiate(objectInChest, spawnPoint.position, spawnPoint.rotation);
        
    }
}
