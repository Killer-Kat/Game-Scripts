using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int playerLevel = 1;
    public int maxLevel = 100;
    public Text levelText;
    public int currentExp;
    public int baseExp = 1000;
    [SerializeField]
    private int[] expToLevelup;
    private HealthManager healthMan;
    private Player_Movement playerMan;
    // Start is called before the first frame update
    void Start()
    {
        levelText.text = "Level: " + playerLevel;
        expToLevelup = new int[maxLevel];
        expToLevelup[1] = baseExp;
        for(int i = 2; i < expToLevelup.Length; i++)
        {
            expToLevelup[i] = Mathf.FloorToInt(expToLevelup[i - 1] * 1.25f);
        }
        healthMan = FindObjectOfType<HealthManager>();
        playerMan = FindObjectOfType<Player_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void giveExp(int expToGive)
    {
        currentExp = currentExp + expToGive;
        upDateStats();
    }
    void upDateStats()
    {
        if (currentExp >= expToLevelup[playerLevel] + expToLevelup[playerLevel + 1])
        {
            playerLevel++;
            healthMan.maxHealth = healthMan.maxHealth + playerLevel;
            healthMan.currentHealth = healthMan.maxHealth;
            playerMan.damage = playerMan.damage + 1;
            if(playerLevel % 2 == 0)
            {
                playerMan.moveSpeed = playerMan.moveSpeed + 0.1f;
            }
        }
        levelText.text = "Level: " + playerLevel;
    }
}
