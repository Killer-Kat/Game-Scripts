using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Vector2 movement;
    public Animator myAnimator;
    private float attackTime = 1f;
    private float attackCounter = 1f;
    private bool isAttacking;
    public int damage = 10;
    public Transform firePoint;
    public GameObject Arrow;
    public Vector2 lastMove;



    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //movement.Normalize();

        myAnimator.SetFloat("Horizontal", movement.x);
        myAnimator.SetFloat("Vertical", movement.y);
        myAnimator.SetFloat("Speed", movement.sqrMagnitude);
        //Sets Idle Direction
        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
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
        if(Input.GetButtonDown("Fire1"))
        {
            attackCounter = attackTime;
            myAnimator.SetBool("IsAttacking", true);
                isAttacking = true;
        }
    }
    void FixedUpdate()
    {
        if (isAttacking == false)
        {
            movement.Normalize();
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
