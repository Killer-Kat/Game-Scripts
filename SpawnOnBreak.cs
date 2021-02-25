using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnBreak : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject enemyToSpawn;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    private bool broken = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void breakAndSpawn()
    {
        if (broken == false)
        {
            spriteRenderer.sprite = newSprite;
            Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
            broken = true;
        }
    }
}
