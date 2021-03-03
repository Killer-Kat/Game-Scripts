using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnDoor : AreaTransition
{
    public bool looseEXP;
    public bool looseItems;
    PlayerStats pStats;
    private AudioManager audioMan;
    // Start is called before the first frame update
    public void Start()
    {
        pStats = FindObjectOfType<PlayerStats>();
        audioMan = FindObjectOfType<AudioManager>();

    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name == "Player" && looseEXP == true)
        {
            pStats.playerLevel = 1;
            pStats.maxHealth = 50;
            pStats.currentHealth = 50;
            pStats.damage = 10;
            pStats.moveSpeed = 5;
            pStats.playerArmor = 0;
            pStats.UIMan.armorGUIupdate();
            pStats.UIMan.expBarUpdate();
            pStats.UIMan.HealthBarUpdate();
            pStats.playerMan.cacheSpeed();
            LoadScene();
        }
        else if(collisionGameObject.name == "Player" && looseItems == true)
        {
            pStats.currentHealth = 50;
            pStats.currentMoney = 0;
            pStats.currentHealthPotions = 0;
            pStats.UIMan.coinGUIupdate();
            pStats.UIMan.healthPotionGUIupdate();
            pStats.UIMan.HealthBarUpdate();
            LoadScene();
        }
        else if(collisionGameObject.name == "Player")
        {
            LoadScene();
        }
    }
}
