using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    private float speed = 20f;
    public Rigidbody2D ArrowRB;
    private Player_Movement playerMan;
    // Start is called before the first frame update
    void Start()
    {
        playerMan = FindObjectOfType<Player_Movement>();
        ArrowRB.velocity = playerMan.lastMove * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //void OnTriggerEnter2D (Collider2D)
   // {

    //}
}
