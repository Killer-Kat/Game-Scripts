using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    private float speed = 15f;
    public Rigidbody2D ArrowRB;
    private PlayerController playerMan;
    // Start is called before the first frame update
    void Start()
    {
        playerMan = FindObjectOfType<PlayerController>();
        ArrowRB.velocity = playerMan.lastMove * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        EnemyController enemy = hitInfo.GetComponent<EnemyController>();
        SpawnOnBreak breakable = hitInfo.GetComponent<SpawnOnBreak>();
        if (enemy != null)
        {
            enemy.TakeDamage(FindObjectOfType<PlayerStats>().damage);
        }
        if (breakable != null)
        {
            breakable.breakAndSpawn();
        }
        Destroy(gameObject);
    }
}
