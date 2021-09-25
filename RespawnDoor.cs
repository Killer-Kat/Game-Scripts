using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnDoor : AreaTransition
{
    public bool looseEXP;
    public bool looseItems;
    private AudioManager audioMan;
    // Start is called before the first frame update
    public void Start()
    {

    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name == "Player" && looseEXP == true)
        {
            PlayerStats.Instance.playerLevel = 1;
            PlayerStats.Instance.currentExp = 0;
            PlayerStats.Instance.maxHealth = 50;
            PlayerStats.Instance.currentHealth = 50;
            PlayerStats.Instance.damage = 10;
            PlayerStats.Instance.moveSpeed = 5;
            PlayerStats.Instance.playerArmor = 0;
            PlayerStats.Instance.UIMan.armorGUIupdate();
            PlayerStats.Instance.UIMan.expBarUpdate();
            PlayerStats.Instance.UIMan.HealthBarUpdate();
            PlayerStats.Instance.playerMan.cacheSpeed();
            LoadScene();
        }
        else if(collisionGameObject.name == "Player" && looseItems == true)
        {
            PlayerStats.Instance.currentHealth = 50;
            PlayerStats.Instance.currentMoney = 0;
            PlayerStats.Instance.currentHealthPotions = 0;
            PlayerStats.Instance.UIMan.coinGUIupdate();
            PlayerStats.Instance.UIMan.healthPotionGUIupdate();
            PlayerStats.Instance.UIMan.HealthBarUpdate();
            LoadScene();
        }
        else if(collisionGameObject.name == "Player")
        {
            //LoadScene();
        }
    }
}
