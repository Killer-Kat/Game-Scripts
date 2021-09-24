using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerController : MonoBehaviour
{
    //public MouseItem mouseItem = new MouseItem();

    Inventory inventory; //making an Inventory object called inventory, our inventory is handled by a different script attached to the player

    public Rigidbody2D rb;
    public Animator myAnimator;
    public SpriteRenderer playerSpriteRenderer;

    public Material LitMaterialRef;
    public Material UnlitMaterialRef;
    
    public bool PickupDelay = false;

    private float attackTime = 1f;
    private float attackCounter = 1f;
    private bool isAttacking;
    public Transform firePoint;
    public GameObject Arrow;
    public Vector2 lastMove;

    public int areaTransitionIndex;
    public bool nextLevelLit;
    private GameObject[] players; //if there is more than one object of the player type in the array it gets deleted, probably deprecated

    private InventoryUI InvUI;
    private PauseMenu pMenu;
    private HealthManager healthMan;
    private PlayerStats pStats;
    private float cachedSpeed;

    bool justLoaded = true;

    [SerializeField] private PlayerInputActions movementAction;
    [SerializeField] private InputAction movement;

    private void Awake()
    {
        movementAction = new PlayerInputActions();
    }
    void OnEnable()
    {
        
        movement = movementAction.Player.Movement;
        movement.Enable();

        movementAction.Player.Attack.performed += Attack;
        movementAction.Player.Attack.Enable();

        movementAction.Player.DrinkHealthPotion.performed += drinkHealthPotionCheck;
        movementAction.Player.DrinkHealthPotion.Enable();

        movementAction.Player.PauseGame.performed += pingPauseMenu;
        movementAction.Player.PauseGame.Enable();

        movementAction.Player.OpenInventory.performed += pingIntventoryUI;
        movementAction.Player.OpenInventory.Enable();
    }

    private void pingIntventoryUI(InputAction.CallbackContext obj)
    {
        InvUI.getPingInvUI();
    }

    private void pingPauseMenu(InputAction.CallbackContext obj)
    {
        pMenu.getPing();
    }

    private void drinkHealthPotionCheck(InputAction.CallbackContext obj)
    {
        if (healthMan.healthPotionCooldown == false && pStats.currentHealthPotions > 0 && PauseMenu.gameIsPaused != true) //Not sure if I should add a nested if statement for the predicate function here or if just adding a Logical AND to the if statement is more performant.
        {
            healthMan.drinkHealthPotion();
            Invoke("ResetPotionCooldown", 3); //Used for idempotency so the player cant spam health potions. change the argument to change the length. 
        }
    }

    private void Attack(InputAction.CallbackContext obj)
    {
        attackCounter = attackTime;
        myAnimator.SetBool("IsAttacking", true);
        isAttacking = true;
    }

    private void OnDisable()
    {
        movement.Disable();
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        InvUI = FindObjectOfType<InventoryUI>();
        pMenu = FindObjectOfType<PauseMenu>();
        healthMan = FindObjectOfType<HealthManager>();
        pStats = FindObjectOfType<PlayerStats>();
        cacheSpeed();
        inventory = Inventory.instance; //setting our inventory object to the singleton
        

    }
    private void OnLevelWasLoaded(int level)
    {
        if(nextLevelLit == true)
        {
            playerSpriteRenderer.material = LitMaterialRef;
        }
        else
        {
            playerSpriteRenderer.material = UnlitMaterialRef;
        }
        FindTransPos();
        
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(movement.ReadValue<Vector2>().ToString());
        if (EventSystem.current.IsPointerOverGameObject())
        {
          //  movement.x = 0;
           // movement.y = 0;
            myAnimator.SetFloat("Speed", 0);
            return;
        }
        
        //Input

        myAnimator.SetFloat("Horizontal", movement.ReadValue<Vector2>().x);
        myAnimator.SetFloat("Vertical", movement.ReadValue<Vector2>().y);
        myAnimator.SetFloat("Speed", movement.ReadValue<Vector2>().sqrMagnitude);
        //Sets Idle Direction
        //There is a bug here where the controller joystick does not use whole values and causes this not to cache, will fix later but low priority
         if (movement.ReadValue<Vector2>().x == 1 || movement.ReadValue<Vector2>().x == -1 || movement.ReadValue<Vector2>().y == 1 || movement.ReadValue<Vector2>().y == -1)
         {
             myAnimator.SetFloat("lastMoveX", movement.ReadValue<Vector2>().x);
             myAnimator.SetFloat("lastMoveY", movement.ReadValue<Vector2>().y);
         }
         if (movement.ReadValue<Vector2>().x == 0 & movement.ReadValue<Vector2>().y == 0)
         {
             //Do Nothing!

         }
         else
         {
             lastMove.x = movement.ReadValue<Vector2>().x; //Input.GetAxisRaw("Horizontal");
             lastMove.y = movement.ReadValue<Vector2>().y; //Input.GetAxisRaw("Vertical");
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
        /*
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            inventory.items[0].Use();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            //
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            pStats.SavePlayer();
            FindObjectOfType<persistenceController>().SaveWorld();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            pStats.LoadPlayer();
        }
        */
    }
    void FixedUpdate()
    {
        if (isAttacking == false)
        {
           
            rb.MovePosition(rb.position + movement.ReadValue<Vector2>() * cachedSpeed * Time.fixedDeltaTime);  //moves the player object
        }
    }
    void FindTransPos()
    {
        if (justLoaded == true)
        {
            justLoaded = false;
        }
        else
        {
            if(areaTransitionIndex == 0)
            {
                //Dont do anything
            }
            else if (areaTransitionIndex == 1)
            {
                transform.position = GameObject.FindWithTag("TransPos").transform.position;
            }
            else if (areaTransitionIndex == 2)
            {
                transform.position = GameObject.FindWithTag("TransPos02").transform.position;
            }
            else if (areaTransitionIndex == 3)
            {
                transform.position = GameObject.FindWithTag("TransPos03").transform.position;
            }
        }
        
    }
    void ResetPotionCooldown()
    {
        healthMan.healthPotionCooldown = false;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<ItemPickup>() != null && PickupDelay == false)
            {
            var item = other.GetComponent<ItemPickup>();
            item.Pickup();
        }
    }
    public void DelayPickup()
    {
        PickupDelay = true;
        Invoke("ResetPickupDelay", 5f);
    }
    public void ResetPickupDelay()
    {
        PickupDelay = false;
    }
    public void cacheSpeed() //If I understand how memeory allocation works this should cache the speed value so we arent grabing it from playerstats every frame.
    {
        cachedSpeed = pStats.moveSpeed + pStats.speedmod;
    }

    private void OnApplicationQuit()
    {
        for (int i = 0; i < inventory.items.Count; i++)
        {
            if (inventory.items[i].isStackable == true)
            {
            inventory.items[i].itemAmount = 1; //We set it to one and not zero or otherwise the first one you pick up wont count because of the way our code is written currently
            }
        }

    }

}
