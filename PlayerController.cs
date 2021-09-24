using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.InputSystem;

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
    private GameObject[] players;

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
    }
    private void OnDisable()
    {
        movement.Disable();
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
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
        Debug.Log(movement.ReadValue<Vector2>().ToString());
        if (EventSystem.current.IsPointerOverGameObject())
        {
            //movement.x = 0;
           // movement.y = 0;
          //  myAnimator.SetFloat("Speed", 0);
            return;
        }
        
        //Input

        myAnimator.SetFloat("Horizontal", movement.ReadValue<Vector2>().x);
        myAnimator.SetFloat("Vertical", movement.ReadValue<Vector2>().y);
        myAnimator.SetFloat("Speed", movement.ReadValue<Vector2>().sqrMagnitude);
        //Sets Idle Direction
       /* if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
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
        } */
        /*
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
                Invoke("ResetPotionCooldown", 3);
            }
        }
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
           
            rb.MovePosition(rb.position + movement.ReadValue<Vector2>() * cachedSpeed * Time.fixedDeltaTime); 
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
