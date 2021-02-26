using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script contains all the values that you want to change durring gameplay and then save to a file.
public class PlayerStats : MonoBehaviour
{
    //Leveling
    public int playerLevel = 1;
    public int currentExp;
    //Money and Inventory
    public int currentMoney;
    //Health and Armor
    public int currentHealthPotions;
    public int currentHealth;
    public int maxHealth;
    public int playerArmor;
    //Weapons and Equipment
    public int damage = 10;
    //General
    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        playerLevel = data.playerLevel;
        currentHealth = data.currentHealth;
        currentExp = data.currentExp;
        currentMoney = data.currentMoney;
        currentHealthPotions = data.currentHealthPotions;
        maxHealth = data.maxHealth;
        playerArmor = data.playerArmor;
        damage = data.damage;
        moveSpeed = data.moveSpeed;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

    }
}
