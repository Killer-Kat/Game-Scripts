﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public MouseItem mouseItem = new MouseItem();

    

    public Rigidbody2D rb;
    public Vector2 movement;
    public Animator myAnimator;

    private float attackTime = 1f;
    private float attackCounter = 1f;
    private bool isAttacking;
    public Transform firePoint;
    public GameObject Arrow;
    public Vector2 lastMove;

    public int areaTransitionIndex;
    private GameObject[] players;

    private HealthManager healthMan;
    private PlayerStats pStats;




    void Start()
    {
        DontDestroyOnLoad(gameObject);
        healthMan = FindObjectOfType<HealthManager>();
        pStats = FindObjectOfType<PlayerStats>();

    }
    private void OnLevelWasLoaded(int level)
    {
        FindTransPos();
        players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length > 1)
        {
            Destroy(players[1]);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            movement.x = 0;
            movement.y = 0;
            return;
        }
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //movement.Normalize();

        myAnimator.SetFloat("Horizontal", movement.x);
        myAnimator.SetFloat("Vertical", movement.y);
        myAnimator.SetFloat("Speed", movement.sqrMagnitude);
        //Sets Idle Direction
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnimator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnimator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
        if (Input.GetAxisRaw("Horizontal") == 0 & Input.GetAxisRaw("Vertical") == 0)
        {
            //Do Nothing!

        }
        else
        {
            lastMove.x = movement.x; //Input.GetAxisRaw("Horizontal");
            lastMove.y = movement.y;//Input.GetAxisRaw("Vertical");
        }
        if (isAttacking)
        {
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                Instantiate(Arrow, firePoint.position, firePoint.rotation);
                myAnimator.SetBool("IsAttacking", false);
                isAttacking = false;
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            attackCounter = attackTime;
            myAnimator.SetBool("IsAttacking", true);
            isAttacking = true;
        }
        if (Input.GetButtonDown("DrinkHealthPotion"))
        {
            if (healthMan.healthPotionCooldown == false && pStats.currentHealthPotions > 0)
            {
                healthMan.drinkHealthPotion();
                Invoke("resetPotionCooldown", 3);
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
          //
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            //
        } 
        if (Input.GetKeyDown(KeyCode.B))
        {
            pStats.SavePlayer();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            pStats.LoadPlayer();
        }

    }
    void FixedUpdate()
    {
        if (isAttacking == false)
        {
            movement.Normalize();
            rb.MovePosition(rb.position + movement * pStats.moveSpeed * Time.fixedDeltaTime); //Note to self cache movespeed with function so the script isnt constantly looking it up here, bonus allows easy speed potion implimentation.
        }
    }
    void FindTransPos()
    {
        if (areaTransitionIndex == 0)
        {
            transform.position = GameObject.FindWithTag("TransPos").transform.position;
        }
        else if (areaTransitionIndex == 1)
        {
            transform.position = GameObject.FindWithTag("TransPos02").transform.position;
        }
    }
    void resetPotionCooldown()
    {
        healthMan.healthPotionCooldown = false;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        var item = other.GetComponent<ItemPickup>();
        item.Pickup();
        //FindObjectOfType<AudioManager>().Play(item.pickUpSound);
    }

    private void OnApplicationQuit()
    {
       
        //Nothing yet

    }

}
