using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
   
    public int maxHealth; //m
    public int playerArmor; //m 
    public int potionHealthAmount = 25; //the amount of health the health potion restores.
    public bool healthPotionCooldown = false;

    private PlayerStats pStats;
    private UIManager UIMan;

    // Start is called before the first frame update
    void Start()
    {
        pStats = FindObjectOfType<PlayerStats>();
        UIMan = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void HurtPlayer(int damageToGive)
    {
        int damageTaken = damageToGive - playerArmor;
        if (damageTaken > 0)
        {
            pStats.currentHealth -= damageToGive;
        }

        if (pStats.currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        UIMan.HealthBarUpdate();
    }
    public void drinkHealthPotion()
    {
        healthPotionCooldown = true;
        pStats.currentHealth = pStats.currentHealth + potionHealthAmount;
        if(pStats.currentHealth > maxHealth)
        {
            pStats.currentHealth = maxHealth;
        }

        FindObjectOfType<AudioManager>().Play("PotionDrink");
        pStats.currentHealthPotions = pStats.currentHealthPotions - 1;
        UIMan.healthPotionGUIupdate();
        UIMan.HealthBarUpdate();
    }
}

