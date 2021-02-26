using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int playerLevel;
    public int currentHealth;
    public int currentExp;
    public int currentMoney;
    public int currentHealthPotions;
    public int maxHealth;
    public int playerArmor;
    public int damage = 10;
    public float moveSpeed = 5f;

    public float[] position;

    public PlayerData (PlayerStats player)
    {
        playerLevel = player.playerLevel;
        currentHealth = player.currentHealth;
        currentExp = player.currentExp;
        currentMoney = player.currentMoney;
        currentHealthPotions = player.currentHealthPotions;
        maxHealth = player.maxHealth;
        playerArmor = player.playerArmor;
        damage = player.damage;
        moveSpeed = player.moveSpeed;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }
}
