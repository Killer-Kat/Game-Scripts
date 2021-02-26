using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public int playerArmor;
    public int potionHealthAmount = 25; //the amount of health the health potion restores.
    public bool healthPotionCooldown = false;

    // Start is called before the first frame update
    void Start()
    {

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
            currentHealth -= damageToGive;
        }

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    public void drinkHealthPotion()
    {
        healthPotionCooldown = true;
        currentHealth = currentHealth + potionHealthAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        FindObjectOfType<AudioManager>().Play("PotionDrink");
        FindObjectOfType<EXPManager>().currentHealthPotions = FindObjectOfType<EXPManager>().currentHealthPotions - 1;
        FindObjectOfType<UIManager>().healthPotionGUIupdate();
    }
}

