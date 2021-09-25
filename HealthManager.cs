using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instace { get; private set; }

    public void Awake()
    {
        if (Instace == null)
        {
            Instace = this;
        }
        else
        {
            Destroy(gameObject); //This shoudl never happen
            Debug.LogError("Health Manager Singleton Duplicate Deleted");
        }
    }

    public int potionHealthAmount = 25; //the amount of health the health potion restores.
    public bool healthPotionCooldown = false;

    private UIManager UIMan;
    private AudioManager audioMan;

    // Start is called before the first frame update
    void Start()
    {
        UIMan = FindObjectOfType<UIManager>();
        audioMan = FindObjectOfType<AudioManager>();
    }
    public void HurtPlayer(int damageToGive)
    {
        int damageTaken = damageToGive - PlayerStats.Instance.playerArmor - PlayerStats.Instance.armormod;
        
        if (damageTaken > 0)
        {
            PlayerStats.Instance.currentHealth -= damageTaken;
        }

        if (PlayerStats.Instance.currentHealth <= 0)
        {
            Die();
        }
        UIMan.HealthBarUpdate();
    }
    public void drinkHealthPotion()
    {
        healthPotionCooldown = true;
        PlayerStats.Instance.currentHealth = PlayerStats.Instance.currentHealth + potionHealthAmount;
        if(PlayerStats.Instance.currentHealth > PlayerStats.Instance.maxHealth)
        {
            PlayerStats.Instance.currentHealth = PlayerStats.Instance.maxHealth;
        }

        FindObjectOfType<AudioManager>().Play("PotionDrink");
        PlayerStats.Instance.currentHealthPotions = PlayerStats.Instance.currentHealthPotions - 1;
        UIMan.healthPotionGUIupdate();
        UIMan.HealthBarUpdate();
    }
    public void Die()
    {
        audioMan.StopAll();
        audioMan.Play("BackGround Music LV0");
        PlayerStats.Instance.playerMan.nextLevelLit = true;
        PlayerStats.Instance.playerMan.areaTransitionIndex = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene(5);
    }
}

