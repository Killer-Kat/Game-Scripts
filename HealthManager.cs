using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int potionHealthAmount = 25; //the amount of health the health potion restores.
    public bool healthPotionCooldown = false;

    private PlayerStats pStats;
    private UIManager UIMan;
    private AudioManager audioMan;

    // Start is called before the first frame update
    void Start()
    {
        pStats = FindObjectOfType<PlayerStats>();
        UIMan = FindObjectOfType<UIManager>();
        audioMan = FindObjectOfType<AudioManager>();
    }
    public void HurtPlayer(int damageToGive)
    {
        int damageTaken = damageToGive - pStats.playerArmor - pStats.armormod;
        
        if (damageTaken > 0)
        {
            pStats.currentHealth -= damageTaken;
        }

        if (pStats.currentHealth <= 0)
        {
            Die();
        }
        UIMan.HealthBarUpdate();
    }
    public void drinkHealthPotion()
    {
        healthPotionCooldown = true;
        pStats.currentHealth = pStats.currentHealth + potionHealthAmount;
        if(pStats.currentHealth > pStats.maxHealth)
        {
            pStats.currentHealth = pStats.maxHealth;
        }

        FindObjectOfType<AudioManager>().Play("PotionDrink");
        pStats.currentHealthPotions = pStats.currentHealthPotions - 1;
        UIMan.healthPotionGUIupdate();
        UIMan.HealthBarUpdate();
    }
    public void Die()
    {
        audioMan.StopAll();
        audioMan.Play("BackGround Music LV0");
        pStats.playerMan.nextLevelLit = true;
        pStats.playerMan.areaTransitionIndex = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene(5);
    }
}

