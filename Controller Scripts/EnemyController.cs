using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    public Transform homePos;
    [SerializeField]
    private int expValue;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;
    //[SerializeField]
    //private int wakeTime = 0;
    public int Health;
    public int dropChance =75;
    public int dropChance1 = 75;
    public GameObject droppedLoot;
    public GameObject droppedLoot1;
    public string DeathSound = "EnemyDeath";
    private EXPManager pStats;
    private AudioManager audioMan;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;
        pStats = FindObjectOfType<EXPManager>();
        audioMan = FindObjectOfType<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {

            FollowPlayer(); //Spoop time
        }
        else if (Vector3.Distance(target.position, transform.position) >= maxRange)
        { 
            GoHome(); // Go home Skele you're drunk!

        }
    }
    public void FollowPlayer()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("MoveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("MoveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
    public void GoHome()
    {
        myAnim.SetFloat("MoveX", (homePos.position.x - transform.position.x));
        myAnim.SetFloat("MoveY", (homePos.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, homePos.position)==0)
        {
            myAnim.SetBool("isMoving", false);
        }
    }
    public void TakeDamage (int damage)
    {
        Health -= damage;
        audioMan.Play("HitSound");
        if (Health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        speed = 0;
        myAnim.Play("DeathEffect");
        audioMan.Play(DeathSound);
        Destroy(gameObject, 0.6f);
        pStats.giveExp(expValue);
        
        int randomValueBetween0And99 = Random.Range(0, 100);
        if(randomValueBetween0And99 < dropChance)
        {
            Instantiate(droppedLoot, transform.position, transform.rotation);
        }
        if (randomValueBetween0And99 < dropChance1)
        {
            if (droppedLoot1 == null)
                droppedLoot1 = droppedLoot;
            Instantiate(droppedLoot1, transform.position, transform.rotation);
        }

    }
}
